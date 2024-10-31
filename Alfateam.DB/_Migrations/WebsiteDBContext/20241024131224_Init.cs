using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alfateam.DB._MigrationsWebsiteDBContext
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Availabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AvailableInAllCountries = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availabilities", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BanInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BanBefore = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BanInfos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HRAccessModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRAccessModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobVacancyExpierences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    YearsFrom = table.Column<int>(type: "int", nullable: true),
                    YearsTo = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVacancyExpierences", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffAccessModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffAccessModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffMatrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffMatrices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PricingMatrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingMatrices", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReviewsAccessModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsAccessModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopAccessModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopAccessModels", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderReturns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ReturnedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderReturns", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guid = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discriminator = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: true),
                    AudioPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageContentItem_Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageContentItem_Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageSliderContentItemId = table.Column<int>(type: "int", nullable: true),
                    ImageSliderContentItem_Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageSliderContentItem_Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoContentItem_Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VideoContentItem_Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentItems_ContentItems_ImageSliderContentItemId",
                        column: x => x.ImageSliderContentItemId,
                        principalTable: "ContentItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContentItems_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRoleModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<int>(type: "int", nullable: false),
                    IsAllCountriesAccess = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ReviewsAccessId = table.Column<int>(type: "int", nullable: false),
                    HRAccessId = table.Column<int>(type: "int", nullable: false),
                    ShopAccessId = table.Column<int>(type: "int", nullable: false),
                    OutstaffAccessId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoleModels_HRAccessModels_HRAccessId",
                        column: x => x.HRAccessId,
                        principalTable: "HRAccessModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleModels_OutstaffAccessModels_OutstaffAccessId",
                        column: x => x.OutstaffAccessId,
                        principalTable: "OutstaffAccessModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleModels_ReviewsAccessModels_ReviewsAccessId",
                        column: x => x.ReviewsAccessId,
                        principalTable: "ReviewsAccessModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleModels_ShopAccessModels_ShopAccessId",
                        column: x => x.ShopAccessId,
                        principalTable: "ShopAccessModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContentAccessModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AccessLevel = table.Column<int>(type: "int", nullable: false),
                    UserRoleModelId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentAccessModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentAccessModels_UserRoleModels_UserRoleModelId",
                        column: x => x.UserRoleModelId,
                        principalTable: "UserRoleModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AboutUsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block1Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block1Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block2HTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block3HTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock5 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock6 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurHistoryHtmlBlock1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurHistoryHtmlBlock2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurHistoryHtmlBlock3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUsPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    District = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCAuthCodeSentPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnGoBack = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCAuthCodeSentPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCAuthLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CCAuthCodeSentPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCAuthRestorePageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCAuthSignInPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCAuthSignUpPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCAuthLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCAuthLocalizationTexts_CCAuthCodeSentPageTexts_CCAuthCodeSe~",
                        column: x => x.CCAuthCodeSentPageTextsId,
                        principalTable: "CCAuthCodeSentPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCAuthRestorePageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnGoBack = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnRestore = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnGoLogin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCAuthRestorePageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCAuthSignInPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnGoBack = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnAuth = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnForgotPassword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCAuthSignInPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCAuthSignUpPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EmailFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepeatPasswordFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RepeatPasswordFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnGoBack = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnRegister = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnIHaveAccount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCAuthSignUpPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCInfoPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeaderPersonalData = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Avatar = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormInputName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormInputNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormInputSurname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormInputSurnamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormInputPatronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormInputPatronymicPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FormBtnSave = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeaderChangePassword = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormOldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormOldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormNewTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormNewPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormRepeatTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormRepeatPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormBtnChangePwd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormErrorInvalidPwd = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormErrorDontMatch = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormErrorValidation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChangePasswordFormErrorComplexity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCInfoPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCMyOrdersPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusDeliveredAt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusWillDeliveredAt = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusCanceled = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCMyOrdersPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCMyProjectsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDeadline = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusCompleted = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusInProgress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCMyProjectsPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCNotificationsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoNotificationsTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCNotificationsPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCOrderPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPriceForOne = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPriceTotal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPriceAmount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalItemsPrice = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryPrice = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderTotalPrice = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnTrackOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCOrderPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCProjectPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectInfo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Milestones = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilestoneStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilestoneStatusInProgress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilestoneStatusCompleted = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MilestoneStatusInWaiting = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectTotalCost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlreadyPaidSum = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SumRemainder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Manager = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCProjectPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCRefAccountPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransactionAdmission = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransactionWithdrawalIndividual = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TransactionWithdrawalLegalEntity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCRefAccountPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCRefLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CCRefAccountPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCRefMainPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCRefMyAccountsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCRefWithdrawalPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCRefLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCRefLocalizationTexts_CCRefAccountPageTexts_CCRefAccountPag~",
                        column: x => x.CCRefAccountPageTextsId,
                        principalTable: "CCRefAccountPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCRefMainPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RulesText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MyRefLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnMyAccounts = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnWithdraw = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefTableHeaderLogin = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefTableHeaderName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefTableHeaderOrdersCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RefTableHeaderActions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCRefMainPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCRefMyAccountsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvailableToWithdraw = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCRefMyAccountsPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCRefWithdrawalPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TabForIndividuals = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TabForLegalEntities = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SumTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SumPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoIndividualCardNumberTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoIndividualCardNumberPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalCompanyNameTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalCompanyNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalCountryTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalCountryPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalRegNumberTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalRegNumberPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalAccountNumberTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalAccountNumberPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalSWIFTTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentInfoLegalSWIFTPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorInsufficientMoney = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorNotAvailableMoney = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCRefWithdrawalPageTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CCWebsiteLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    CCAuthLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    CCRefLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    CCInfoPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCMyOrdersPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCMyProjectsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCNotificationsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCOrderPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CCProjectPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CCWebsiteLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCAuthLocalizationTexts_CCAuthLoc~",
                        column: x => x.CCAuthLocalizationTextsId,
                        principalTable: "CCAuthLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCInfoPageTexts_CCInfoPageTextsId",
                        column: x => x.CCInfoPageTextsId,
                        principalTable: "CCInfoPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCMyOrdersPageTexts_CCMyOrdersPag~",
                        column: x => x.CCMyOrdersPageTextsId,
                        principalTable: "CCMyOrdersPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCMyProjectsPageTexts_CCMyProject~",
                        column: x => x.CCMyProjectsPageTextsId,
                        principalTable: "CCMyProjectsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCNotificationsPageTexts_CCNotifi~",
                        column: x => x.CCNotificationsPageTextsId,
                        principalTable: "CCNotificationsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCOrderPageTexts_CCOrderPageTexts~",
                        column: x => x.CCOrderPageTextsId,
                        principalTable: "CCOrderPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCProjectPageTexts_CCProjectPageT~",
                        column: x => x.CCProjectPageTextsId,
                        principalTable: "CCProjectPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CCWebsiteLocalizationTexts_CCRefLocalizationTexts_CCRefLocal~",
                        column: x => x.CCRefLocalizationTextsId,
                        principalTable: "CCRefLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientCabinetCommonTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Info = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MyOrders = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Favorites = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notifications = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MyProjects = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReferralProgram = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logout = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCabinetCommonTexts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CommonTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    HeaderId = table.Column<int>(type: "int", nullable: false),
                    FooterId = table.Column<int>(type: "int", nullable: false),
                    LinksId = table.Column<int>(type: "int", nullable: false),
                    ClientCabinetId = table.Column<int>(type: "int", nullable: false),
                    MainBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MoreBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PlaceholderAll = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommonTexts_ClientCabinetCommonTexts_ClientCabinetId",
                        column: x => x.ClientCabinetId,
                        principalTable: "ClientCabinetCommonTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComplianceDocumentLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KBSize = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPreviewPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComplianceDocumentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceDocumentLocalizations", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComplianceDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KBSize = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPreviewPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DocumentPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceDocuments_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComplianceTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplianceTexts_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CorporateCulturePageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCulturePageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateCulturePageTexts_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Costs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "double", nullable: false),
                    PricingMatrixItemId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Costs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OfficialMainLanguageId = table.Column<int>(type: "int", nullable: false),
                    MainCurrencyId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    AvailabilityId = table.Column<int>(type: "int", nullable: true),
                    AvailabilityId1 = table.Column<int>(type: "int", nullable: true),
                    UserRoleModelId = table.Column<int>(type: "int", nullable: true),
                    UserRoleModelId1 = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_Availabilities_AvailabilityId1",
                        column: x => x.AvailabilityId1,
                        principalTable: "Availabilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_UserRoleModels_UserRoleModelId",
                        column: x => x.UserRoleModelId,
                        principalTable: "UserRoleModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_UserRoleModels_UserRoleModelId1",
                        column: x => x.UserRoleModelId1,
                        principalTable: "UserRoleModels",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PricingMatrixItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    PricingMatrixId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PricingMatrixItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PricingMatrixItems_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PricingMatrixItems_PricingMatrices_PricingMatrixId",
                        column: x => x.PricingMatrixId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CountryCurrency",
                columns: table => new
                {
                    CountryManyToManyRefsId = table.Column<int>(type: "int", nullable: false),
                    CurrenciesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCurrency", x => new { x.CountryManyToManyRefsId, x.CurrenciesId });
                    table.ForeignKey(
                        name: "FK_CountryCurrency_Countries_CountryManyToManyRefsId",
                        column: x => x.CountryManyToManyRefsId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CountryLanguage",
                columns: table => new
                {
                    CountryManyToManyRefsId = table.Column<int>(type: "int", nullable: false),
                    LanguagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLanguage", x => new { x.CountryManyToManyRefsId, x.LanguagesId });
                    table.ForeignKey(
                        name: "FK_CountryLanguage_Countries_CountryManyToManyRefsId",
                        column: x => x.CountryManyToManyRefsId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CountryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CountryLocalizations_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CountrySites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    MainCurrencyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountrySites", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LanguageEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRightToLeft = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: true),
                    CountrySiteId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageEntities_CountrySites_CountrySiteId",
                        column: x => x.CountrySiteId,
                        principalTable: "CountrySites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LanguageEntities_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Symbol = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Currencies_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCategories_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCategories_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFormats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventFormats_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventFormats_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Format = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Topic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventsSearch = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormInputName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormInputNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormInputPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormInputPhonePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormInputDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormInputDescriptionPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormBtnSend = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BookingFormError = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FindMyAgreementPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementNumberTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementNumberPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementCustomerNameTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementCustomerNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnFindAgreement = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementInfoHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementResultNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementResultSum = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementResultTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementResultDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnDownloadPDF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnDownloadDOCX = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgreementNotFound = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FindMyAgreementPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FindMyAgreementPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FooterTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AllRightReserved = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Team = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Partners = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    News = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Contacts = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LeaveRequest = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurWorks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicesCost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AboutUs = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FooterTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FooterTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FraudCounteractionPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FraudCounteractionPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FraudCounteractionPageTexts_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FraudCounteractionPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HeaderTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Main = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurWorks = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cost = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Services = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkForUs = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    More = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WriteUs = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeaderTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeaderTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HRJobVacanciesListPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchVacancyPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FindJobBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NowWatchingAmountText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NowWatching2_3_4_AmountText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SendRequest = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceFrom1Year = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceFromPlural = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceTo1Year = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceToPlural = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceFrom0To1Year = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpierenceFromToPlural = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterNameEducation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterNameWorkTime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterNameIncomeLevel = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRJobVacanciesListPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRJobVacanciesListPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HRJobVacancyPageText",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    KeySkills = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormInputName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormInputNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormInputPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormInputPhonePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormInputDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormInputDescriptionPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormBtnSend = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormBtnAttach = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVFormError = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRJobVacancyPageText", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRJobVacancyPageText_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ILQualityAndPipelinePageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockGoToProjectBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricProjectsInWork = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricProjectsInYear = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricProjectsTotal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricTeammatesCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock5 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurAdvantagesHtmlBlock6 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStagesHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage5 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastProjectsHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurServicesHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientsReviewsHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILQualityAndPipelinePageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ILQualityAndPipelinePageTexts_LanguageEntities_LanguageEntit~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ILRefProgramPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockColumn1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockColumn2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockColumn3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockBtnLeaveRequest = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonsBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonsBlockPaymentsHTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonsBlockCRMHTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonsBlockReliabilityHTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReasonsBlockStratigiesHTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeProposeBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeProposeBlock_HTMLContentForBusiness = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WeProposeBlock_HTMLContentForFreelancer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WhichServicesYouCanProposeHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentProcedureHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentProcedureHTMLBlock1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentProcedureHTMLBlock2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentProcedureHTMLBlock3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUs = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUsScale1Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUsScale1Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUsScale2Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUsScale2Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUsScale3Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkStartWithUsScale3Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILRefProgramPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ILRefProgramPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ILWorkWithUsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockWantToTeamBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurPhilosophyBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurPhilosophyBlockHtmlColumn1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurPhilosophyBlockHtmlColumn2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurPhilosophyBlockHtmlColumn3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkInAlfateamBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkInAlfateamBlockLargeText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkInAlfateamBlockLowerText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvailableVacanciesHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LiveInOurCompanyHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AlreadyJoinedUsHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ILWorkWithUsPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ILWorkWithUsPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestProjectPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GetProjectPresentationBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OtherInvestProjectsHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestProjectPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestProjectPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestProjectsListPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockColumn1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockColumn2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockColumn3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricYearsOfWork = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricProjectsCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricCountriesCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricOfficesCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricCompanyProductsCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MetricCompanyEmployeesCount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InvestProjectsHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurPartnersHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWorkHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWork_Header1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWork_Text1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWork_Header2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWork_Text2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWork_Header3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrinciplesOfWork_Text3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurInvestorsReviewsHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormInputNameTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormInputNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormInputPhoneTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormInputPhonePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormInputTextTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormInputTextPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormSendBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormErrorValidation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormErrorPhoneValidation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactWithUsFormSuccess = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestProjectsListPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestProjectsListPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LandingTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockStartProjectBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurProjectsBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurProjectsBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurProjectsBlockMoreBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStagesHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStagesShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectDevelopmentStage5 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockOurAddresses = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockOurEmails = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockEmails = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockOurPhones = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurContactsBlockPhones = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormInputNameTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormInputNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormInputPhoneTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormInputPhonePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormInputTextTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormInputTextPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormSendBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormErrorValidation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContactMeFormErrorPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandingTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandingTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LanguageLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LanguageMainModelId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguageLocalizations_LanguageEntities_LanguageMainModelId",
                        column: x => x.LanguageMainModelId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LinksLocalization",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VkontakteLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InstagramLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacebookLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TwitterLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelegramLink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksLocalization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinksLocalization_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MassMediaAboutUsTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnotherNews = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassMediaAboutUsTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MassMediaAboutUsTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MassMediaPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClicksCount = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassMediaPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MassMediaPosts_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MassMediaPosts_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    OutstaffMatrixId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffColumns_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffColumns_OutstaffMatrices_OutstaffMatrixId",
                        column: x => x.OutstaffMatrixId,
                        principalTable: "OutstaffMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    OutstaffMatrixId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffItems_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffItems_OutstaffMatrices_OutstaffMatrixId",
                        column: x => x.OutstaffMatrixId,
                        principalTable: "OutstaffMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortTextAfterHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnLeaveRequest = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnFillBrief = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdvantagesBlockTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdvantagesBlockText1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdvantagesBlockText2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdvantagesBlockText3 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdvantagesBlockText4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HowOutstaffWorksBlockTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HowOutstaffWorksBlockHtmlContent1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HowOutstaffWorksBlockHtmlContent2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportsBlockTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportsBlockHtmlContent1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReportsBlockHtmlContent2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DevelopmentTypesBlockTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DevelopmentTypesBlockHtmlContent1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DevelopmentTypesBlockHtmlContent2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partners_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Partners_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartnersPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BtnShowReview = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnersPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnersPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioCategories_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioCategories_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioIndustries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioIndustries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioIndustries_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioIndustries_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioItemPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectPeculiarities = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectStack = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioItemPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioItemPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioListPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastBreadcrumpChrono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeaderChrono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Directions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Industries = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioListPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioListPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioStatsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterYearTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterYearPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterMonthTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterMonthPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FilterBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioStatsPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioStatsPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategories_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategories_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostIndustries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostIndustries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostIndustries_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostIndustries_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Directions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Industries = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Search = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchTextBoxPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SearchBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnotherNews = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostsPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostsPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PrivacyPolicyPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrivacyPolicyPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrivacyPolicyPageTexts_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrivacyPolicyPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Promocodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsReusable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PriceFromId = table.Column<int>(type: "int", nullable: true),
                    PriceToId = table.Column<int>(type: "int", nullable: true),
                    Percent = table.Column<double>(type: "double", nullable: true),
                    DiscountId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promocodes_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promocodes_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promocodes_PricingMatrices_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Promocodes_PricingMatrices_PriceFromId",
                        column: x => x.PriceFromId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Promocodes_PricingMatrices_PriceToId",
                        column: x => x.PriceToId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReviewsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormYourRate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormNameTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormTitleTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormTitlePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormDescriptionTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormDescriptionPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormProjectLinkTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormProjectLinkPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewFormBtnSend = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReview = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReviewBtnDelete = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReviewBtnEdit = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReviewBtnSaveChanges = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReviewDeleteConfirmation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReviewDeleteConfirmationYes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    YourReviewDeleteConfirmationNot = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewsPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReviewsPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block2Col1HTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block2Col2HTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePages_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePages_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicePageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WriteUsBtn = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MakeAnyProject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurProject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OurStack = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReviewsAboutService = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaybeBeInteresting = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicesListPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesListPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesListPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopBasketPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MiddleBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPriceForOne = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPriceTotal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ItemPriceAmount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalItemsPrice = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveryPrice = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliverySetAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderTotalPrice = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PromocodeFieldTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PromocodeFieldPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnMakeOrder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnClearBasket = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClearBasketConfirmation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClearBasketConfirmationYes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClearBasketConfirmationNo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmptyBasketText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopBasketPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopBasketPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopDeliveryAddressPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MiddleBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputCountry = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputCountryPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputCity = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputCityPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputAddressPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputZIP = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputZIPPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputPhone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputPhonePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputNamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputSurname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputSurnamePlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputPatronymic = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressFormInputPatronymicPlaceholder = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopDeliveryAddressPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopDeliveryAddressPageTexts_LanguageEntities_LanguageEntity~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopItemPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MiddleBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnAddToBasket = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccordionAdditionalInfo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccordionAdditionalInfoTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItemPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopItemsPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Category = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceSortTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceSortAsc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PriceSortDesc = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BtnSort = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemsPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItemsPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderNotPaidPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorInvalidCVV = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorInvalidOther = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorInsufficientMoney = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorBankDeclined = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorOther = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderNotPaidPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrderNotPaidPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderPaidSuccessfullyPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderPaidSuccessfullyPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrderPaidSuccessfullyPageTexts_LanguageEntities_Language~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProductCategories_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductCategories_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SitemapPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SitemapPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SitemapPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamMemberPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectZero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectSingle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Project2_3_4 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProjectPlural = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AboutMember = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MemberSkills = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MemberPortfolio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMemberPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMemberPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamPageTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    LastBreadcrump = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Header = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPageTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamPageTexts_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamPageTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamStructures_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamStructures_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimeZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Offset = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeZones_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CurrencyLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyLocalizations_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrencyLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobVacancies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    SalaryFrom = table.Column<double>(type: "double", nullable: true),
                    SalaryTo = table.Column<double>(type: "double", nullable: true),
                    InnerContentId = table.Column<int>(type: "int", nullable: false),
                    ExpierenceId = table.Column<int>(type: "int", nullable: false),
                    Watches = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVacancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobVacancies_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancies_Content_InnerContentId",
                        column: x => x.InnerContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancies_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancies_JobVacancyExpierences_ExpierenceId",
                        column: x => x.ExpierenceId,
                        principalTable: "JobVacancyExpierences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancies_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventCategoryLocalizations_EventCategories_EventCategoryId",
                        column: x => x.EventCategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventCategoryLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventFormatLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventFormatId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFormatLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventFormatLocalizations_EventFormats_EventFormatId",
                        column: x => x.EventFormatId,
                        principalTable: "EventFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventFormatLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InnerLandingsLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ILQualityAndPipelinePageTextsId = table.Column<int>(type: "int", nullable: false),
                    ILRefProgramPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ILWorkWithUsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerLandingsLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InnerLandingsLocalizationTexts_ILQualityAndPipelinePageTexts~",
                        column: x => x.ILQualityAndPipelinePageTextsId,
                        principalTable: "ILQualityAndPipelinePageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerLandingsLocalizationTexts_ILRefProgramPageTexts_ILRefPr~",
                        column: x => x.ILRefProgramPageTextsId,
                        principalTable: "ILRefProgramPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerLandingsLocalizationTexts_ILWorkWithUsPageTexts_ILWorkW~",
                        column: x => x.ILWorkWithUsPageTextsId,
                        principalTable: "ILWorkWithUsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InnerLandingsLocalizationTexts_LanguageEntities_LanguageEnti~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MassMediaPostLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MassMediaPostId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MassMediaPostLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MassMediaPostLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MassMediaPostLocalizations_MassMediaPosts_MassMediaPostId",
                        column: x => x.MassMediaPostId,
                        principalTable: "MassMediaPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffColumnLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutstaffColumnId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffColumnLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffColumnLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffColumnLocalizations_OutstaffColumns_OutstaffColumnId",
                        column: x => x.OutstaffColumnId,
                        principalTable: "OutstaffColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffItemGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    OutstaffItemId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffItemGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGrades_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGrades_OutstaffItems_OutstaffItemId",
                        column: x => x.OutstaffItemId,
                        principalTable: "OutstaffItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffItemLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutstaffItemId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffItemLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffItemLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffItemLocalizations_OutstaffItems_OutstaffItemId",
                        column: x => x.OutstaffItemId,
                        principalTable: "OutstaffItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartnerLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    PartnerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartnerLocalizations_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartnerLocalizations_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PortfolioCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioCategoryLocalizations_LanguageEntities_LanguageEnti~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioCategoryLocalizations_PortfolioCategories_Portfolio~",
                        column: x => x.PortfolioCategoryId,
                        principalTable: "PortfolioCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioIndustryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PortfolioIndustryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioIndustryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioIndustryLocalizations_LanguageEntities_LanguageEnti~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioIndustryLocalizations_PortfolioIndustries_Portfolio~",
                        column: x => x.PortfolioIndustryId,
                        principalTable: "PortfolioIndustries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    Watches = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Portfolios_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_PortfolioCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PortfolioCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Portfolios_PortfolioIndustries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "PortfolioIndustries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostCategoryLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostCategoryLocalizations_PostCategories_PostCategoryId",
                        column: x => x.PostCategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostIndustryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostIndustryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostIndustryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostIndustryLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostIndustryLocalizations_PostIndustries_PostIndustryId",
                        column: x => x.PostIndustryId,
                        principalTable: "PostIndustries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IndustryId = table.Column<int>(type: "int", nullable: false),
                    Watches = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PostCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_PostIndustries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "PostIndustries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicePageLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MainBlockHeader = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainBlockShortText = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block2Col1HTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Block2Col2HTMLContent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicePageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePageLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePageLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServicePageLocalizations_ServicePages_ServicePageId",
                        column: x => x.ServicePageId,
                        principalTable: "ServicePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicePageStackIcons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicePageId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePageStackIcons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePageStackIcons_ServicePages_ServicePageId",
                        column: x => x.ServicePageId,
                        principalTable: "ServicePages",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopProductCategoryLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShopProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProductCategoryLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProductCategoryLocalizations_LanguageEntities_LanguageEn~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductCategoryLocalizations_ShopProductCategories_ShopP~",
                        column: x => x.ShopProductCategoryId,
                        principalTable: "ShopProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WebsiteLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ComplianceTextsId = table.Column<int>(type: "int", nullable: false),
                    EventTextsId = table.Column<int>(type: "int", nullable: false),
                    MassMediaAboutUsTextsId = table.Column<int>(type: "int", nullable: false),
                    OutstaffPageTextsId = table.Column<int>(type: "int", nullable: false),
                    PartnersPageTextsId = table.Column<int>(type: "int", nullable: false),
                    PostsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ReviewsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ServicePageTextsId = table.Column<int>(type: "int", nullable: false),
                    SitemapPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_ComplianceTexts_ComplianceTextsId",
                        column: x => x.ComplianceTextsId,
                        principalTable: "ComplianceTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_EventTexts_EventTextsId",
                        column: x => x.EventTextsId,
                        principalTable: "EventTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_MassMediaAboutUsTexts_MassMediaAbou~",
                        column: x => x.MassMediaAboutUsTextsId,
                        principalTable: "MassMediaAboutUsTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_OutstaffPageTexts_OutstaffPageTexts~",
                        column: x => x.OutstaffPageTextsId,
                        principalTable: "OutstaffPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_PartnersPageTexts_PartnersPageTexts~",
                        column: x => x.PartnersPageTextsId,
                        principalTable: "PartnersPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_PostsPageTexts_PostsPageTextsId",
                        column: x => x.PostsPageTextsId,
                        principalTable: "PostsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_ReviewsPageTexts_ReviewsPageTextsId",
                        column: x => x.ReviewsPageTextsId,
                        principalTable: "ReviewsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_ServicePageTexts_ServicePageTextsId",
                        column: x => x.ServicePageTextsId,
                        principalTable: "ServicePageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WebsiteLocalizationTexts_SitemapPageTexts_SitemapPageTextsId",
                        column: x => x.SitemapPageTextsId,
                        principalTable: "SitemapPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    TeamStructureId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamGroups_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamGroups_TeamStructures_TeamStructureId",
                        column: x => x.TeamStructureId,
                        principalTable: "TeamStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventOrganizer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventMembers = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeZoneId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    FormatId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "EventCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventFormats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "EventFormats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TimezoneLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeZoneId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimezoneLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimezoneLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TimezoneLocalizations_TimeZones_TimeZoneId",
                        column: x => x.TimeZoneId,
                        principalTable: "TimeZones",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobVacancyLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InnerContentId = table.Column<int>(type: "int", nullable: false),
                    JobVacancyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobVacancyLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobVacancyLocalizations_Content_InnerContentId",
                        column: x => x.InnerContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancyLocalizations_JobVacancies_JobVacancyId",
                        column: x => x.JobVacancyId,
                        principalTable: "JobVacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobVacancyLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffItemGradeColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ColumnId = table.Column<int>(type: "int", nullable: false),
                    OutstaffItemGradeId = table.Column<int>(type: "int", nullable: false),
                    CostPerHourId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffItemGradeColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGradeColumns_OutstaffColumns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "OutstaffColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGradeColumns_OutstaffItemGrades_OutstaffItemGrad~",
                        column: x => x.OutstaffItemGradeId,
                        principalTable: "OutstaffItemGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGradeColumns_PricingMatrices_CostPerHourId",
                        column: x => x.CostPerHourId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OutstaffItemGradeLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OutstaffItemGradeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutstaffItemGradeLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGradeLocalizations_LanguageEntities_LanguageEnti~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutstaffItemGradeLocalizations_OutstaffItemGrades_OutstaffIt~",
                        column: x => x.OutstaffItemGradeId,
                        principalTable: "OutstaffItemGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    PortfolioId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizations_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizations_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ContentId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostLocalizations_Content_ContentId",
                        column: x => x.ContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostLocalizations_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicePageFakeReviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CustomerTitle = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerPosition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CustomerAvatarPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicePageId = table.Column<int>(type: "int", nullable: true),
                    ServicePageLocalizationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePageFakeReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePageFakeReviews_ServicePageLocalizations_ServicePageL~",
                        column: x => x.ServicePageLocalizationId,
                        principalTable: "ServicePageLocalizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServicePageFakeReviews_ServicePages_ServicePageId",
                        column: x => x.ServicePageId,
                        principalTable: "ServicePages",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ServicePageServiceRibbonItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicePageId = table.Column<int>(type: "int", nullable: true),
                    ServicePageLocalizationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePageServiceRibbonItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicePageServiceRibbonItems_ServicePageLocalizations_Servi~",
                        column: x => x.ServicePageLocalizationId,
                        principalTable: "ServicePageLocalizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServicePageServiceRibbonItems_ServicePages_ServicePageId",
                        column: x => x.ServicePageId,
                        principalTable: "ServicePages",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "HRLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    HRJobVacanciesListPageTextsId = table.Column<int>(type: "int", nullable: false),
                    HRJobVacancyPageTextId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRLocalizationTexts_HRJobVacanciesListPageTexts_HRJobVacanci~",
                        column: x => x.HRJobVacanciesListPageTextsId,
                        principalTable: "HRJobVacanciesListPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HRLocalizationTexts_HRJobVacancyPageText_HRJobVacancyPageTex~",
                        column: x => x.HRJobVacancyPageTextId,
                        principalTable: "HRJobVacancyPageText",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HRLocalizationTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HRLocalizationTexts_WebsiteLocalizationTexts_WebsiteLocaliza~",
                        column: x => x.WebsiteLocalizationTextsId,
                        principalTable: "WebsiteLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InvestLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    InvestProjectPageTextsId = table.Column<int>(type: "int", nullable: false),
                    InvestProjectsListPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvestLocalizationTexts_InvestProjectPageTexts_InvestProject~",
                        column: x => x.InvestProjectPageTextsId,
                        principalTable: "InvestProjectPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestLocalizationTexts_InvestProjectsListPageTexts_InvestPr~",
                        column: x => x.InvestProjectsListPageTextsId,
                        principalTable: "InvestProjectsListPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestLocalizationTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvestLocalizationTexts_WebsiteLocalizationTexts_WebsiteLoca~",
                        column: x => x.WebsiteLocalizationTextsId,
                        principalTable: "WebsiteLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PortfolioLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    PortfolioItemPageTextsId = table.Column<int>(type: "int", nullable: false),
                    PortfolioListPageTextsId = table.Column<int>(type: "int", nullable: false),
                    PortfolioStatsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortfolioLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizationTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizationTexts_PortfolioItemPageTexts_PortfolioI~",
                        column: x => x.PortfolioItemPageTextsId,
                        principalTable: "PortfolioItemPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizationTexts_PortfolioListPageTexts_PortfolioL~",
                        column: x => x.PortfolioListPageTextsId,
                        principalTable: "PortfolioListPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizationTexts_PortfolioStatsPageTexts_Portfolio~",
                        column: x => x.PortfolioStatsPageTextsId,
                        principalTable: "PortfolioStatsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PortfolioLocalizationTexts_WebsiteLocalizationTexts_WebsiteL~",
                        column: x => x.WebsiteLocalizationTextsId,
                        principalTable: "WebsiteLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    ShopBasketPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ShopDeliveryAddressPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ShopItemPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ShopItemsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ShopOrderNotPaidPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ShopOrderPaidSuccessfullyPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_ShopBasketPageTexts_ShopBasketPageText~",
                        column: x => x.ShopBasketPageTextsId,
                        principalTable: "ShopBasketPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_ShopDeliveryAddressPageTexts_ShopDeliv~",
                        column: x => x.ShopDeliveryAddressPageTextsId,
                        principalTable: "ShopDeliveryAddressPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_ShopItemPageTexts_ShopItemPageTextsId",
                        column: x => x.ShopItemPageTextsId,
                        principalTable: "ShopItemPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_ShopItemsPageTexts_ShopItemsPageTextsId",
                        column: x => x.ShopItemsPageTextsId,
                        principalTable: "ShopItemsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_ShopOrderNotPaidPageTexts_ShopOrderNot~",
                        column: x => x.ShopOrderNotPaidPageTextsId,
                        principalTable: "ShopOrderNotPaidPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_ShopOrderPaidSuccessfullyPageTexts_Sho~",
                        column: x => x.ShopOrderPaidSuccessfullyPageTextsId,
                        principalTable: "ShopOrderPaidSuccessfullyPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopLocalizationTexts_WebsiteLocalizationTexts_WebsiteLocali~",
                        column: x => x.WebsiteLocalizationTextsId,
                        principalTable: "WebsiteLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaticPagesLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    InnerLandingsLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    AboutUsPageTextsId = table.Column<int>(type: "int", nullable: false),
                    CorporateCulturePageTextsId = table.Column<int>(type: "int", nullable: false),
                    FindMyAgreementPageTextsId = table.Column<int>(type: "int", nullable: false),
                    FraudCounteractionPageTextsId = table.Column<int>(type: "int", nullable: false),
                    LandingTextsId = table.Column<int>(type: "int", nullable: false),
                    PrivacyPolicyPageTextsId = table.Column<int>(type: "int", nullable: false),
                    ServicesListPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaticPagesLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_AboutUsPageTexts_AboutUsPageTex~",
                        column: x => x.AboutUsPageTextsId,
                        principalTable: "AboutUsPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_CorporateCulturePageTexts_Corpo~",
                        column: x => x.CorporateCulturePageTextsId,
                        principalTable: "CorporateCulturePageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_FindMyAgreementPageTexts_FindMy~",
                        column: x => x.FindMyAgreementPageTextsId,
                        principalTable: "FindMyAgreementPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_FraudCounteractionPageTexts_Fra~",
                        column: x => x.FraudCounteractionPageTextsId,
                        principalTable: "FraudCounteractionPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_InnerLandingsLocalizationTexts_~",
                        column: x => x.InnerLandingsLocalizationTextsId,
                        principalTable: "InnerLandingsLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_LandingTexts_LandingTextsId",
                        column: x => x.LandingTextsId,
                        principalTable: "LandingTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_LanguageEntities_LanguageEntity~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_PrivacyPolicyPageTexts_PrivacyP~",
                        column: x => x.PrivacyPolicyPageTextsId,
                        principalTable: "PrivacyPolicyPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_ServicesListPageTexts_ServicesL~",
                        column: x => x.ServicesListPageTextsId,
                        principalTable: "ServicesListPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaticPagesLocalizationTexts_WebsiteLocalizationTexts_Websit~",
                        column: x => x.WebsiteLocalizationTextsId,
                        principalTable: "WebsiteLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamLocalizationTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WebsiteLocalizationTextsId = table.Column<int>(type: "int", nullable: false),
                    TeamMemberPageTextsId = table.Column<int>(type: "int", nullable: false),
                    TeamPageTextsId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamLocalizationTexts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamLocalizationTexts_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLocalizationTexts_TeamMemberPageTexts_TeamMemberPageText~",
                        column: x => x.TeamMemberPageTextsId,
                        principalTable: "TeamMemberPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLocalizationTexts_TeamPageTexts_TeamPageTextsId",
                        column: x => x.TeamPageTextsId,
                        principalTable: "TeamPageTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamLocalizationTexts_WebsiteLocalizationTexts_WebsiteLocali~",
                        column: x => x.WebsiteLocalizationTextsId,
                        principalTable: "WebsiteLocalizationTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamGroupLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamGroupId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamGroupLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamGroupLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamGroupLocalizations_TeamGroups_TeamGroupId",
                        column: x => x.TeamGroupId,
                        principalTable: "TeamGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortExpierence = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quote = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DetailContentId = table.Column<int>(type: "int", nullable: false),
                    CVFilepath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    TeamGroupId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_Content_DetailContentId",
                        column: x => x.DetailContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMembers_TeamGroups_TeamGroupId",
                        column: x => x.TeamGroupId,
                        principalTable: "TeamGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventOrganizer = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventMembers = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLocalizations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TeamMemberLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShortExpierence = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quote = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DetailContentId = table.Column<int>(type: "int", nullable: false),
                    CVFilepath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TeamMemberId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMemberLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMemberLocalizations_Content_DetailContentId",
                        column: x => x.DetailContentId,
                        principalTable: "Content",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMemberLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamMemberLocalizations_TeamMembers_TeamMemberId",
                        column: x => x.TeamMemberId,
                        principalTable: "TeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AboutInfo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CVPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedByFingerprint = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Note = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobVacancyId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSummaries_JobVacancies_JobVacancyId",
                        column: x => x.JobVacancyId,
                        principalTable: "JobVacancies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductModifierItemLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductModifierItemId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModifierItemLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModifierItemLocalizations_LanguageEntities_LanguageEn~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductModifierItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PricingId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "varchar(21)", maxLength: 21, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    ProductModifierId = table.Column<int>(type: "int", nullable: false),
                    ColorHex = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModifierItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModifierItems_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModifierItems_PricingMatrices_PricingId",
                        column: x => x.PricingId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductModifierLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductModifierId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModifierLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModifierLocalizations_LanguageEntities_LanguageEntity~",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AllowMultipleSelection = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    ShopProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductModifiers_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RateVotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SetAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    SetById = table.Column<int>(type: "int", nullable: true),
                    SetByFingerprint = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PortfolioId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateVotes_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PublishedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsHidden = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    URLToProject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SessID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiresAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeactivated = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderItemModifierOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OptionId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    PriceForOne = table.Column<double>(type: "double", nullable: false),
                    ShopOrderItemModifierId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderItemModifierOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrderItemModifierOptions_ProductModifierItems_OptionId",
                        column: x => x.OptionId,
                        principalTable: "ProductModifierItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderItemModifiers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ModifierId = table.Column<int>(type: "int", nullable: false),
                    ShopOrderItemId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderItemModifiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrderItemModifiers_ProductModifiers_ModifierId",
                        column: x => x.ModifierId,
                        principalTable: "ProductModifiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "double", nullable: false),
                    PriceForOne = table.Column<double>(type: "double", nullable: false),
                    ShopOrderId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderItems", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrderPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Sum = table.Column<double>(type: "double", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    InitiatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MerchantService = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShopOrderId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrderPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrderPayments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TrackingURL = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsedPromocodeId = table.Column<int>(type: "int", nullable: true),
                    UsedPromocodeType = table.Column<int>(type: "int", nullable: true),
                    DiscountByPromocode = table.Column<double>(type: "double", nullable: true),
                    ReturnId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopOrders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopOrders_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopOrders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopOrders_Promocodes_UsedPromocodeId",
                        column: x => x.UsedPromocodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShopOrders_ShopOrderReturns_ReturnId",
                        column: x => x.ReturnId,
                        principalTable: "ShopOrderReturns",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Patronymic = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AvatarPath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BanInfoId = table.Column<int>(type: "int", nullable: true),
                    BindedCRMUser = table.Column<int>(type: "int", nullable: true),
                    RoleModelId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    RegisteredFromCountryId = table.Column<int>(type: "int", nullable: true),
                    BasketId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BanInfos_BanInfoId",
                        column: x => x.BanInfoId,
                        principalTable: "BanInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Countries_RegisteredFromCountryId",
                        column: x => x.RegisteredFromCountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_ShopOrders_BasketId",
                        column: x => x.BasketId,
                        principalTable: "ShopOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserRoleModels_RoleModelId",
                        column: x => x.RoleModelId,
                        principalTable: "UserRoleModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopWishlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopWishlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopWishlists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SiteVisits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VisitedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    URL = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserAgent = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IP = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    Fingerprint = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VisitedById = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteVisits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteVisits_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SiteVisits_Users_VisitedById",
                        column: x => x.VisitedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsedPromocodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PromocodeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedPromocodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedPromocodes_Promocodes_PromocodeId",
                        column: x => x.PromocodeId,
                        principalTable: "Promocodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedPromocodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Watches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WatchedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    WatchedById = table.Column<int>(type: "int", nullable: true),
                    WatchedByFingerprint = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobVacancyId = table.Column<int>(type: "int", nullable: true),
                    PortfolioId = table.Column<int>(type: "int", nullable: true),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Watches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Watches_JobVacancies_JobVacancyId",
                        column: x => x.JobVacancyId,
                        principalTable: "JobVacancies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Watches_Portfolios_PortfolioId",
                        column: x => x.PortfolioId,
                        principalTable: "Portfolios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Watches_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Watches_Users_WatchedById",
                        column: x => x.WatchedById,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImgPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShopProductId = table.Column<int>(type: "int", nullable: true),
                    ShopProductLocalizationId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProductImages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SKU = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MainImageId = table.Column<int>(type: "int", nullable: false),
                    BasePricingId = table.Column<int>(type: "int", nullable: false),
                    MainLanguageId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AvailabilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProducts_Availabilities_AvailabilityId",
                        column: x => x.AvailabilityId,
                        principalTable: "Availabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProducts_LanguageEntities_MainLanguageId",
                        column: x => x.MainLanguageId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProducts_PricingMatrices_BasePricingId",
                        column: x => x.BasePricingId,
                        principalTable: "PricingMatrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProducts_ShopProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ShopProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProducts_ShopProductImages_MainImageId",
                        column: x => x.MainImageId,
                        principalTable: "ShopProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopProductLocalizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UseLocalizationImages = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MainImageId = table.Column<int>(type: "int", nullable: false),
                    ShopProductId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LanguageEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopProductLocalizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopProductLocalizations_LanguageEntities_LanguageEntityId",
                        column: x => x.LanguageEntityId,
                        principalTable: "LanguageEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductLocalizations_ShopProductImages_MainImageId",
                        column: x => x.MainImageId,
                        principalTable: "ShopProductImages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopProductLocalizations_ShopProducts_ShopProductId",
                        column: x => x.ShopProductId,
                        principalTable: "ShopProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShopWishlistItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AddedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ShopWishlistId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopWishlistItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopWishlistItems_ShopProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ShopProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopWishlistItems_ShopWishlists_ShopWishlistId",
                        column: x => x.ShopWishlistId,
                        principalTable: "ShopWishlists",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AboutUsPageTexts_LanguageEntityId",
                table: "AboutUsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthCodeSentPageTexts_LanguageEntityId",
                table: "CCAuthCodeSentPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthLocalizationTexts_CCAuthCodeSentPageTextsId",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthCodeSentPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthLocalizationTexts_CCAuthRestorePageTextsId",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthRestorePageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthLocalizationTexts_CCAuthSignInPageTextsId",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthSignInPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthLocalizationTexts_CCAuthSignUpPageTextsId",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthSignUpPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthLocalizationTexts_LanguageEntityId",
                table: "CCAuthLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthRestorePageTexts_LanguageEntityId",
                table: "CCAuthRestorePageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthSignInPageTexts_LanguageEntityId",
                table: "CCAuthSignInPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCAuthSignUpPageTexts_LanguageEntityId",
                table: "CCAuthSignUpPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCInfoPageTexts_LanguageEntityId",
                table: "CCInfoPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCMyOrdersPageTexts_LanguageEntityId",
                table: "CCMyOrdersPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCMyProjectsPageTexts_LanguageEntityId",
                table: "CCMyProjectsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCNotificationsPageTexts_LanguageEntityId",
                table: "CCNotificationsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCOrderPageTexts_LanguageEntityId",
                table: "CCOrderPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCProjectPageTexts_LanguageEntityId",
                table: "CCProjectPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefAccountPageTexts_LanguageEntityId",
                table: "CCRefAccountPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefLocalizationTexts_CCRefAccountPageTextsId",
                table: "CCRefLocalizationTexts",
                column: "CCRefAccountPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefLocalizationTexts_CCRefMainPageTextsId",
                table: "CCRefLocalizationTexts",
                column: "CCRefMainPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefLocalizationTexts_CCRefMyAccountsPageTextsId",
                table: "CCRefLocalizationTexts",
                column: "CCRefMyAccountsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefLocalizationTexts_CCRefWithdrawalPageTextsId",
                table: "CCRefLocalizationTexts",
                column: "CCRefWithdrawalPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefLocalizationTexts_LanguageEntityId",
                table: "CCRefLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefMainPageTexts_LanguageEntityId",
                table: "CCRefMainPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefMyAccountsPageTexts_LanguageEntityId",
                table: "CCRefMyAccountsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCRefWithdrawalPageTexts_LanguageEntityId",
                table: "CCRefWithdrawalPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCAuthLocalizationTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCAuthLocalizationTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCInfoPageTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCInfoPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCMyOrdersPageTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCMyOrdersPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCMyProjectsPageTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCMyProjectsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCNotificationsPageTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCNotificationsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCOrderPageTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCOrderPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCProjectPageTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCProjectPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_CCRefLocalizationTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "CCRefLocalizationTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_LanguageEntityId",
                table: "CCWebsiteLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CCWebsiteLocalizationTexts_WebsiteLocalizationTextsId",
                table: "CCWebsiteLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientCabinetCommonTexts_LanguageEntityId",
                table: "ClientCabinetCommonTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_ClientCabinetId",
                table: "CommonTexts",
                column: "ClientCabinetId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_FooterId",
                table: "CommonTexts",
                column: "FooterId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_HeaderId",
                table: "CommonTexts",
                column: "HeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_LanguageEntityId",
                table: "CommonTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_LinksId",
                table: "CommonTexts",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_CommonTexts_WebsiteLocalizationTextsId",
                table: "CommonTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDocumentLocalizations_ComplianceDocumentId",
                table: "ComplianceDocumentLocalizations",
                column: "ComplianceDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDocumentLocalizations_LanguageEntityId",
                table: "ComplianceDocumentLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDocuments_AvailabilityId",
                table: "ComplianceDocuments",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceDocuments_MainLanguageId",
                table: "ComplianceDocuments",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceTexts_ContentId",
                table: "ComplianceTexts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplianceTexts_LanguageEntityId",
                table: "ComplianceTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentAccessModels_UserRoleModelId",
                table: "ContentAccessModels",
                column: "UserRoleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentItems_ContentId",
                table: "ContentItems",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_ContentItems_ImageSliderContentItemId",
                table: "ContentItems",
                column: "ImageSliderContentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCulturePageTexts_ContentId",
                table: "CorporateCulturePageTexts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_CorporateCulturePageTexts_LanguageEntityId",
                table: "CorporateCulturePageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_CurrencyId",
                table: "Costs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_PricingMatrixItemId",
                table: "Costs",
                column: "PricingMatrixItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AvailabilityId",
                table: "Countries",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_AvailabilityId1",
                table: "Countries",
                column: "AvailabilityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_MainCurrencyId",
                table: "Countries",
                column: "MainCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_MainLanguageId",
                table: "Countries",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_OfficialMainLanguageId",
                table: "Countries",
                column: "OfficialMainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UserRoleModelId",
                table: "Countries",
                column: "UserRoleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_UserRoleModelId1",
                table: "Countries",
                column: "UserRoleModelId1");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCurrency_CurrenciesId",
                table: "CountryCurrency",
                column: "CurrenciesId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLanguage_LanguagesId",
                table: "CountryLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLocalizations_CountryId",
                table: "CountryLocalizations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryLocalizations_LanguageEntityId",
                table: "CountryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySites_MainCurrencyId",
                table: "CountrySites",
                column: "MainCurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountrySites_MainLanguageId",
                table: "CountrySites",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Currencies_MainLanguageId",
                table: "Currencies",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLocalizations_CurrencyId",
                table: "CurrencyLocalizations",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyLocalizations_LanguageEntityId",
                table: "CurrencyLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_AvailabilityId",
                table: "EventCategories",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_MainLanguageId",
                table: "EventCategories",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategoryLocalizations_EventCategoryId",
                table: "EventCategoryLocalizations",
                column: "EventCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategoryLocalizations_LanguageEntityId",
                table: "EventCategoryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFormatLocalizations_EventFormatId",
                table: "EventFormatLocalizations",
                column: "EventFormatId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFormatLocalizations_LanguageEntityId",
                table: "EventFormatLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFormats_AvailabilityId",
                table: "EventFormats",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventFormats_MainLanguageId",
                table: "EventFormats",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLocalizations_EventId",
                table: "EventLocalizations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLocalizations_LanguageEntityId",
                table: "EventLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AvailabilityId",
                table: "Events",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_FormatId",
                table: "Events",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_MainLanguageId",
                table: "Events",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TimeZoneId",
                table: "Events",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTexts_LanguageEntityId",
                table: "EventTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FindMyAgreementPageTexts_LanguageEntityId",
                table: "FindMyAgreementPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FooterTexts_LanguageEntityId",
                table: "FooterTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_FraudCounteractionPageTexts_ContentId",
                table: "FraudCounteractionPageTexts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_FraudCounteractionPageTexts_LanguageEntityId",
                table: "FraudCounteractionPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HeaderTexts_LanguageEntityId",
                table: "HeaderTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HRJobVacanciesListPageTexts_LanguageEntityId",
                table: "HRJobVacanciesListPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HRJobVacancyPageText_LanguageEntityId",
                table: "HRJobVacancyPageText",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HRLocalizationTexts_HRJobVacanciesListPageTextsId",
                table: "HRLocalizationTexts",
                column: "HRJobVacanciesListPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_HRLocalizationTexts_HRJobVacancyPageTextId",
                table: "HRLocalizationTexts",
                column: "HRJobVacancyPageTextId");

            migrationBuilder.CreateIndex(
                name: "IX_HRLocalizationTexts_LanguageEntityId",
                table: "HRLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HRLocalizationTexts_WebsiteLocalizationTextsId",
                table: "HRLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ILQualityAndPipelinePageTexts_LanguageEntityId",
                table: "ILQualityAndPipelinePageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ILRefProgramPageTexts_LanguageEntityId",
                table: "ILRefProgramPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ILWorkWithUsPageTexts_LanguageEntityId",
                table: "ILWorkWithUsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerLandingsLocalizationTexts_ILQualityAndPipelinePageTexts~",
                table: "InnerLandingsLocalizationTexts",
                column: "ILQualityAndPipelinePageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerLandingsLocalizationTexts_ILRefProgramPageTextsId",
                table: "InnerLandingsLocalizationTexts",
                column: "ILRefProgramPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerLandingsLocalizationTexts_ILWorkWithUsPageTextsId",
                table: "InnerLandingsLocalizationTexts",
                column: "ILWorkWithUsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_InnerLandingsLocalizationTexts_LanguageEntityId",
                table: "InnerLandingsLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestLocalizationTexts_InvestProjectPageTextsId",
                table: "InvestLocalizationTexts",
                column: "InvestProjectPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestLocalizationTexts_InvestProjectsListPageTextsId",
                table: "InvestLocalizationTexts",
                column: "InvestProjectsListPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestLocalizationTexts_LanguageEntityId",
                table: "InvestLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestLocalizationTexts_WebsiteLocalizationTextsId",
                table: "InvestLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvestProjectPageTexts_LanguageEntityId",
                table: "InvestProjectPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_InvestProjectsListPageTexts_LanguageEntityId",
                table: "InvestProjectsListPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSummaries_CreatedById",
                table: "JobSummaries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobSummaries_JobVacancyId",
                table: "JobSummaries",
                column: "JobVacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_AvailabilityId",
                table: "JobVacancies",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_CurrencyId",
                table: "JobVacancies",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_ExpierenceId",
                table: "JobVacancies",
                column: "ExpierenceId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_InnerContentId",
                table: "JobVacancies",
                column: "InnerContentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancies_MainLanguageId",
                table: "JobVacancies",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancyLocalizations_InnerContentId",
                table: "JobVacancyLocalizations",
                column: "InnerContentId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancyLocalizations_JobVacancyId",
                table: "JobVacancyLocalizations",
                column: "JobVacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobVacancyLocalizations_LanguageEntityId",
                table: "JobVacancyLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LandingTexts_LanguageEntityId",
                table: "LandingTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntities_CountrySiteId",
                table: "LanguageEntities",
                column: "CountrySiteId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageEntities_MainLanguageId",
                table: "LanguageEntities",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageLocalizations_LanguageEntityId",
                table: "LanguageLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguageLocalizations_LanguageMainModelId",
                table: "LanguageLocalizations",
                column: "LanguageMainModelId");

            migrationBuilder.CreateIndex(
                name: "IX_LinksLocalization_LanguageEntityId",
                table: "LinksLocalization",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MassMediaAboutUsTexts_LanguageEntityId",
                table: "MassMediaAboutUsTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MassMediaPostLocalizations_LanguageEntityId",
                table: "MassMediaPostLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MassMediaPostLocalizations_MassMediaPostId",
                table: "MassMediaPostLocalizations",
                column: "MassMediaPostId");

            migrationBuilder.CreateIndex(
                name: "IX_MassMediaPosts_AvailabilityId",
                table: "MassMediaPosts",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_MassMediaPosts_MainLanguageId",
                table: "MassMediaPosts",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffColumnLocalizations_LanguageEntityId",
                table: "OutstaffColumnLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffColumnLocalizations_OutstaffColumnId",
                table: "OutstaffColumnLocalizations",
                column: "OutstaffColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffColumns_MainLanguageId",
                table: "OutstaffColumns",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffColumns_OutstaffMatrixId",
                table: "OutstaffColumns",
                column: "OutstaffMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGradeColumns_ColumnId",
                table: "OutstaffItemGradeColumns",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGradeColumns_CostPerHourId",
                table: "OutstaffItemGradeColumns",
                column: "CostPerHourId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGradeColumns_OutstaffItemGradeId",
                table: "OutstaffItemGradeColumns",
                column: "OutstaffItemGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGradeLocalizations_LanguageEntityId",
                table: "OutstaffItemGradeLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGradeLocalizations_OutstaffItemGradeId",
                table: "OutstaffItemGradeLocalizations",
                column: "OutstaffItemGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGrades_MainLanguageId",
                table: "OutstaffItemGrades",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemGrades_OutstaffItemId",
                table: "OutstaffItemGrades",
                column: "OutstaffItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemLocalizations_LanguageEntityId",
                table: "OutstaffItemLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItemLocalizations_OutstaffItemId",
                table: "OutstaffItemLocalizations",
                column: "OutstaffItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItems_MainLanguageId",
                table: "OutstaffItems",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffItems_OutstaffMatrixId",
                table: "OutstaffItems",
                column: "OutstaffMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_OutstaffPageTexts_LanguageEntityId",
                table: "OutstaffPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerLocalizations_ContentId",
                table: "PartnerLocalizations",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerLocalizations_LanguageEntityId",
                table: "PartnerLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnerLocalizations_PartnerId",
                table: "PartnerLocalizations",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_AvailabilityId",
                table: "Partners",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_ContentId",
                table: "Partners",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_MainLanguageId",
                table: "Partners",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PartnersPageTexts_LanguageEntityId",
                table: "PartnersPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategories_AvailabilityId",
                table: "PortfolioCategories",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategories_MainLanguageId",
                table: "PortfolioCategories",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategoryLocalizations_LanguageEntityId",
                table: "PortfolioCategoryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioCategoryLocalizations_PortfolioCategoryId",
                table: "PortfolioCategoryLocalizations",
                column: "PortfolioCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIndustries_AvailabilityId",
                table: "PortfolioIndustries",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIndustries_MainLanguageId",
                table: "PortfolioIndustries",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIndustryLocalizations_LanguageEntityId",
                table: "PortfolioIndustryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioIndustryLocalizations_PortfolioIndustryId",
                table: "PortfolioIndustryLocalizations",
                column: "PortfolioIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioItemPageTexts_LanguageEntityId",
                table: "PortfolioItemPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioListPageTexts_LanguageEntityId",
                table: "PortfolioListPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizations_ContentId",
                table: "PortfolioLocalizations",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizations_LanguageEntityId",
                table: "PortfolioLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizations_PortfolioId",
                table: "PortfolioLocalizations",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizationTexts_LanguageEntityId",
                table: "PortfolioLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizationTexts_PortfolioItemPageTextsId",
                table: "PortfolioLocalizationTexts",
                column: "PortfolioItemPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizationTexts_PortfolioListPageTextsId",
                table: "PortfolioLocalizationTexts",
                column: "PortfolioListPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizationTexts_PortfolioStatsPageTextsId",
                table: "PortfolioLocalizationTexts",
                column: "PortfolioStatsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioLocalizationTexts_WebsiteLocalizationTextsId",
                table: "PortfolioLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_AvailabilityId",
                table: "Portfolios",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_CategoryId",
                table: "Portfolios",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_ContentId",
                table: "Portfolios",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_IndustryId",
                table: "Portfolios",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolios_MainLanguageId",
                table: "Portfolios",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PortfolioStatsPageTexts_LanguageEntityId",
                table: "PortfolioStatsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_AvailabilityId",
                table: "PostCategories",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_MainLanguageId",
                table: "PostCategories",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryLocalizations_LanguageEntityId",
                table: "PostCategoryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategoryLocalizations_PostCategoryId",
                table: "PostCategoryLocalizations",
                column: "PostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIndustries_AvailabilityId",
                table: "PostIndustries",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIndustries_MainLanguageId",
                table: "PostIndustries",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIndustryLocalizations_LanguageEntityId",
                table: "PostIndustryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostIndustryLocalizations_PostIndustryId",
                table: "PostIndustryLocalizations",
                column: "PostIndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLocalizations_ContentId",
                table: "PostLocalizations",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLocalizations_LanguageEntityId",
                table: "PostLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PostLocalizations_PostId",
                table: "PostLocalizations",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AvailabilityId",
                table: "Posts",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ContentId",
                table: "Posts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IndustryId",
                table: "Posts",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_MainLanguageId",
                table: "Posts",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PostsPageTexts_LanguageEntityId",
                table: "PostsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PricingMatrixItems_CountryId",
                table: "PricingMatrixItems",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PricingMatrixItems_PricingMatrixId",
                table: "PricingMatrixItems",
                column: "PricingMatrixId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivacyPolicyPageTexts_ContentId",
                table: "PrivacyPolicyPageTexts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_PrivacyPolicyPageTexts_LanguageEntityId",
                table: "PrivacyPolicyPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierItemLocalizations_LanguageEntityId",
                table: "ProductModifierItemLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierItemLocalizations_ProductModifierItemId",
                table: "ProductModifierItemLocalizations",
                column: "ProductModifierItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierItems_MainLanguageId",
                table: "ProductModifierItems",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierItems_PricingId",
                table: "ProductModifierItems",
                column: "PricingId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierItems_ProductModifierId",
                table: "ProductModifierItems",
                column: "ProductModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierLocalizations_LanguageEntityId",
                table: "ProductModifierLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifierLocalizations_ProductModifierId",
                table: "ProductModifierLocalizations",
                column: "ProductModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifiers_MainLanguageId",
                table: "ProductModifiers",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModifiers_ShopProductId",
                table: "ProductModifiers",
                column: "ShopProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_AvailabilityId",
                table: "Promocodes",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_DiscountId",
                table: "Promocodes",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_MainLanguageId",
                table: "Promocodes",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_PriceFromId",
                table: "Promocodes",
                column: "PriceFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Promocodes_PriceToId",
                table: "Promocodes",
                column: "PriceToId");

            migrationBuilder.CreateIndex(
                name: "IX_RateVotes_PortfolioId",
                table: "RateVotes",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_RateVotes_SetById",
                table: "RateVotes",
                column: "SetById");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CountryId",
                table: "Reviews",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewsPageTexts_LanguageEntityId",
                table: "ReviewsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageFakeReviews_ServicePageId",
                table: "ServicePageFakeReviews",
                column: "ServicePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageFakeReviews_ServicePageLocalizationId",
                table: "ServicePageFakeReviews",
                column: "ServicePageLocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageLocalizations_LanguageEntityId",
                table: "ServicePageLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageLocalizations_ServicePageId",
                table: "ServicePageLocalizations",
                column: "ServicePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePages_AvailabilityId",
                table: "ServicePages",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePages_MainLanguageId",
                table: "ServicePages",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageServiceRibbonItems_ServicePageId",
                table: "ServicePageServiceRibbonItems",
                column: "ServicePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageServiceRibbonItems_ServicePageLocalizationId",
                table: "ServicePageServiceRibbonItems",
                column: "ServicePageLocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageStackIcons_ServicePageId",
                table: "ServicePageStackIcons",
                column: "ServicePageId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicePageTexts_LanguageEntityId",
                table: "ServicePageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesListPageTexts_LanguageEntityId",
                table: "ServicesListPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopBasketPageTexts_LanguageEntityId",
                table: "ShopBasketPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopDeliveryAddressPageTexts_LanguageEntityId",
                table: "ShopDeliveryAddressPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemPageTexts_LanguageEntityId",
                table: "ShopItemPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemsPageTexts_LanguageEntityId",
                table: "ShopItemsPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_LanguageEntityId",
                table: "ShopLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_ShopBasketPageTextsId",
                table: "ShopLocalizationTexts",
                column: "ShopBasketPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_ShopDeliveryAddressPageTextsId",
                table: "ShopLocalizationTexts",
                column: "ShopDeliveryAddressPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_ShopItemPageTextsId",
                table: "ShopLocalizationTexts",
                column: "ShopItemPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_ShopItemsPageTextsId",
                table: "ShopLocalizationTexts",
                column: "ShopItemsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_ShopOrderNotPaidPageTextsId",
                table: "ShopLocalizationTexts",
                column: "ShopOrderNotPaidPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_ShopOrderPaidSuccessfullyPageTextsId",
                table: "ShopLocalizationTexts",
                column: "ShopOrderPaidSuccessfullyPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopLocalizationTexts_WebsiteLocalizationTextsId",
                table: "ShopLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderItemModifierOptions_OptionId",
                table: "ShopOrderItemModifierOptions",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderItemModifierOptions_ShopOrderItemModifierId",
                table: "ShopOrderItemModifierOptions",
                column: "ShopOrderItemModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderItemModifiers_ModifierId",
                table: "ShopOrderItemModifiers",
                column: "ModifierId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderItemModifiers_ShopOrderItemId",
                table: "ShopOrderItemModifiers",
                column: "ShopOrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderItems_ItemId",
                table: "ShopOrderItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderItems_ShopOrderId",
                table: "ShopOrderItems",
                column: "ShopOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderNotPaidPageTexts_LanguageEntityId",
                table: "ShopOrderNotPaidPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderPaidSuccessfullyPageTexts_LanguageEntityId",
                table: "ShopOrderPaidSuccessfullyPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderPayments_CurrencyId",
                table: "ShopOrderPayments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrderPayments_ShopOrderId",
                table: "ShopOrderPayments",
                column: "ShopOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_AddressId",
                table: "ShopOrders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_CountryId",
                table: "ShopOrders",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_CreatedById",
                table: "ShopOrders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_CurrencyId",
                table: "ShopOrders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_ReturnId",
                table: "ShopOrders",
                column: "ReturnId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopOrders_UsedPromocodeId",
                table: "ShopOrders",
                column: "UsedPromocodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductCategories_AvailabilityId",
                table: "ShopProductCategories",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductCategories_MainLanguageId",
                table: "ShopProductCategories",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductCategoryLocalizations_LanguageEntityId",
                table: "ShopProductCategoryLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductCategoryLocalizations_ShopProductCategoryId",
                table: "ShopProductCategoryLocalizations",
                column: "ShopProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductImages_ShopProductId",
                table: "ShopProductImages",
                column: "ShopProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductImages_ShopProductLocalizationId",
                table: "ShopProductImages",
                column: "ShopProductLocalizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductLocalizations_LanguageEntityId",
                table: "ShopProductLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductLocalizations_MainImageId",
                table: "ShopProductLocalizations",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProductLocalizations_ShopProductId",
                table: "ShopProductLocalizations",
                column: "ShopProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_AvailabilityId",
                table: "ShopProducts",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_BasePricingId",
                table: "ShopProducts",
                column: "BasePricingId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_CategoryId",
                table: "ShopProducts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_MainImageId",
                table: "ShopProducts",
                column: "MainImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopProducts_MainLanguageId",
                table: "ShopProducts",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopWishlistItems_ProductId",
                table: "ShopWishlistItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopWishlistItems_ShopWishlistId",
                table: "ShopWishlistItems",
                column: "ShopWishlistId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopWishlists_UserId",
                table: "ShopWishlists",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SitemapPageTexts_LanguageEntityId",
                table: "SitemapPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisits_CountryId",
                table: "SiteVisits",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteVisits_VisitedById",
                table: "SiteVisits",
                column: "VisitedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_AboutUsPageTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "AboutUsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_CorporateCulturePageTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "CorporateCulturePageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_FindMyAgreementPageTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "FindMyAgreementPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_FraudCounteractionPageTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "FraudCounteractionPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_InnerLandingsLocalizationTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "InnerLandingsLocalizationTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_LandingTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "LandingTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_LanguageEntityId",
                table: "StaticPagesLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_PrivacyPolicyPageTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "PrivacyPolicyPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_ServicesListPageTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "ServicesListPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_StaticPagesLocalizationTexts_WebsiteLocalizationTextsId",
                table: "StaticPagesLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamGroupLocalizations_LanguageEntityId",
                table: "TeamGroupLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGroupLocalizations_TeamGroupId",
                table: "TeamGroupLocalizations",
                column: "TeamGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGroups_MainLanguageId",
                table: "TeamGroups",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamGroups_TeamStructureId",
                table: "TeamGroups",
                column: "TeamStructureId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLocalizationTexts_LanguageEntityId",
                table: "TeamLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLocalizationTexts_TeamMemberPageTextsId",
                table: "TeamLocalizationTexts",
                column: "TeamMemberPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLocalizationTexts_TeamPageTextsId",
                table: "TeamLocalizationTexts",
                column: "TeamPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamLocalizationTexts_WebsiteLocalizationTextsId",
                table: "TeamLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberLocalizations_DetailContentId",
                table: "TeamMemberLocalizations",
                column: "DetailContentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberLocalizations_LanguageEntityId",
                table: "TeamMemberLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberLocalizations_TeamMemberId",
                table: "TeamMemberLocalizations",
                column: "TeamMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMemberPageTexts_LanguageEntityId",
                table: "TeamMemberPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_DetailContentId",
                table: "TeamMembers",
                column: "DetailContentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_MainLanguageId",
                table: "TeamMembers",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_TeamGroupId",
                table: "TeamMembers",
                column: "TeamGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPageTexts_ContentId",
                table: "TeamPageTexts",
                column: "ContentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamPageTexts_LanguageEntityId",
                table: "TeamPageTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStructures_AvailabilityId",
                table: "TeamStructures",
                column: "AvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamStructures_MainLanguageId",
                table: "TeamStructures",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_TimezoneLocalizations_LanguageEntityId",
                table: "TimezoneLocalizations",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TimezoneLocalizations_TimeZoneId",
                table: "TimezoneLocalizations",
                column: "TimeZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeZones_MainLanguageId",
                table: "TimeZones",
                column: "MainLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedPromocodes_PromocodeId",
                table: "UsedPromocodes",
                column: "PromocodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedPromocodes_UserId",
                table: "UsedPromocodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleModels_HRAccessId",
                table: "UserRoleModels",
                column: "HRAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleModels_OutstaffAccessId",
                table: "UserRoleModels",
                column: "OutstaffAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleModels_ReviewsAccessId",
                table: "UserRoleModels",
                column: "ReviewsAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleModels_ShopAccessId",
                table: "UserRoleModels",
                column: "ShopAccessId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BanInfoId",
                table: "Users",
                column: "BanInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BasketId",
                table: "Users",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegisteredFromCountryId",
                table: "Users",
                column: "RegisteredFromCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleModelId",
                table: "Users",
                column: "RoleModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_JobVacancyId",
                table: "Watches",
                column: "JobVacancyId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_PortfolioId",
                table: "Watches",
                column: "PortfolioId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_PostId",
                table: "Watches",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Watches_WatchedById",
                table: "Watches",
                column: "WatchedById");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_ComplianceTextsId",
                table: "WebsiteLocalizationTexts",
                column: "ComplianceTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_EventTextsId",
                table: "WebsiteLocalizationTexts",
                column: "EventTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_LanguageEntityId",
                table: "WebsiteLocalizationTexts",
                column: "LanguageEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_MassMediaAboutUsTextsId",
                table: "WebsiteLocalizationTexts",
                column: "MassMediaAboutUsTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_OutstaffPageTextsId",
                table: "WebsiteLocalizationTexts",
                column: "OutstaffPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_PartnersPageTextsId",
                table: "WebsiteLocalizationTexts",
                column: "PartnersPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_PostsPageTextsId",
                table: "WebsiteLocalizationTexts",
                column: "PostsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_ReviewsPageTextsId",
                table: "WebsiteLocalizationTexts",
                column: "ReviewsPageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_ServicePageTextsId",
                table: "WebsiteLocalizationTexts",
                column: "ServicePageTextsId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteLocalizationTexts_SitemapPageTextsId",
                table: "WebsiteLocalizationTexts",
                column: "SitemapPageTextsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutUsPageTexts_LanguageEntities_LanguageEntityId",
                table: "AboutUsPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthCodeSentPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCAuthCodeSentPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthLocalizationTexts_CCAuthRestorePageTexts_CCAuthRestore~",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthRestorePageTextsId",
                principalTable: "CCAuthRestorePageTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthLocalizationTexts_CCAuthSignInPageTexts_CCAuthSignInPa~",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthSignInPageTextsId",
                principalTable: "CCAuthSignInPageTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthLocalizationTexts_CCAuthSignUpPageTexts_CCAuthSignUpPa~",
                table: "CCAuthLocalizationTexts",
                column: "CCAuthSignUpPageTextsId",
                principalTable: "CCAuthSignUpPageTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthLocalizationTexts_LanguageEntities_LanguageEntityId",
                table: "CCAuthLocalizationTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthRestorePageTexts_LanguageEntities_LanguageEntityId",
                table: "CCAuthRestorePageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthSignInPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCAuthSignInPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCAuthSignUpPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCAuthSignUpPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCInfoPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCInfoPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCMyOrdersPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCMyOrdersPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCMyProjectsPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCMyProjectsPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCNotificationsPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCNotificationsPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCOrderPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCOrderPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCProjectPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCProjectPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefAccountPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCRefAccountPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefLocalizationTexts_CCRefMainPageTexts_CCRefMainPageTexts~",
                table: "CCRefLocalizationTexts",
                column: "CCRefMainPageTextsId",
                principalTable: "CCRefMainPageTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefLocalizationTexts_CCRefMyAccountsPageTexts_CCRefMyAccou~",
                table: "CCRefLocalizationTexts",
                column: "CCRefMyAccountsPageTextsId",
                principalTable: "CCRefMyAccountsPageTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefLocalizationTexts_CCRefWithdrawalPageTexts_CCRefWithdra~",
                table: "CCRefLocalizationTexts",
                column: "CCRefWithdrawalPageTextsId",
                principalTable: "CCRefWithdrawalPageTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefLocalizationTexts_LanguageEntities_LanguageEntityId",
                table: "CCRefLocalizationTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefMainPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCRefMainPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefMyAccountsPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCRefMyAccountsPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCRefWithdrawalPageTexts_LanguageEntities_LanguageEntityId",
                table: "CCRefWithdrawalPageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCWebsiteLocalizationTexts_LanguageEntities_LanguageEntityId",
                table: "CCWebsiteLocalizationTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CCWebsiteLocalizationTexts_WebsiteLocalizationTexts_WebsiteL~",
                table: "CCWebsiteLocalizationTexts",
                column: "WebsiteLocalizationTextsId",
                principalTable: "WebsiteLocalizationTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCabinetCommonTexts_LanguageEntities_LanguageEntityId",
                table: "ClientCabinetCommonTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommonTexts_FooterTexts_FooterId",
                table: "CommonTexts",
                column: "FooterId",
                principalTable: "FooterTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommonTexts_HeaderTexts_HeaderId",
                table: "CommonTexts",
                column: "HeaderId",
                principalTable: "HeaderTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommonTexts_LanguageEntities_LanguageEntityId",
                table: "CommonTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommonTexts_LinksLocalization_LinksId",
                table: "CommonTexts",
                column: "LinksId",
                principalTable: "LinksLocalization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommonTexts_WebsiteLocalizationTexts_WebsiteLocalizationText~",
                table: "CommonTexts",
                column: "WebsiteLocalizationTextsId",
                principalTable: "WebsiteLocalizationTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceDocumentLocalizations_ComplianceDocuments_Complian~",
                table: "ComplianceDocumentLocalizations",
                column: "ComplianceDocumentId",
                principalTable: "ComplianceDocuments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceDocumentLocalizations_LanguageEntities_LanguageEnt~",
                table: "ComplianceDocumentLocalizations",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceDocuments_LanguageEntities_MainLanguageId",
                table: "ComplianceDocuments",
                column: "MainLanguageId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplianceTexts_LanguageEntities_LanguageEntityId",
                table: "ComplianceTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CorporateCulturePageTexts_LanguageEntities_LanguageEntityId",
                table: "CorporateCulturePageTexts",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Currencies_CurrencyId",
                table: "Costs",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_PricingMatrixItems_PricingMatrixItemId",
                table: "Costs",
                column: "PricingMatrixItemId",
                principalTable: "PricingMatrixItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Currencies_MainCurrencyId",
                table: "Countries",
                column: "MainCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_LanguageEntities_MainLanguageId",
                table: "Countries",
                column: "MainLanguageId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_LanguageEntities_OfficialMainLanguageId",
                table: "Countries",
                column: "OfficialMainLanguageId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryCurrency_Currencies_CurrenciesId",
                table: "CountryCurrency",
                column: "CurrenciesId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryLanguage_LanguageEntities_LanguagesId",
                table: "CountryLanguage",
                column: "LanguagesId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountryLocalizations_LanguageEntities_LanguageEntityId",
                table: "CountryLocalizations",
                column: "LanguageEntityId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_Currencies_MainCurrencyId",
                table: "CountrySites",
                column: "MainCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CountrySites_LanguageEntities_MainLanguageId",
                table: "CountrySites",
                column: "MainLanguageId",
                principalTable: "LanguageEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSummaries_Users_CreatedById",
                table: "JobSummaries",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModifierItemLocalizations_ProductModifierItems_Produc~",
                table: "ProductModifierItemLocalizations",
                column: "ProductModifierItemId",
                principalTable: "ProductModifierItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModifierItems_ProductModifiers_ProductModifierId",
                table: "ProductModifierItems",
                column: "ProductModifierId",
                principalTable: "ProductModifiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModifierLocalizations_ProductModifiers_ProductModifie~",
                table: "ProductModifierLocalizations",
                column: "ProductModifierId",
                principalTable: "ProductModifiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductModifiers_ShopProducts_ShopProductId",
                table: "ProductModifiers",
                column: "ShopProductId",
                principalTable: "ShopProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RateVotes_Users_SetById",
                table: "RateVotes",
                column: "SetById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Users_UserId",
                table: "Sessions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOrderItemModifierOptions_ShopOrderItemModifiers_ShopOrde~",
                table: "ShopOrderItemModifierOptions",
                column: "ShopOrderItemModifierId",
                principalTable: "ShopOrderItemModifiers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOrderItemModifiers_ShopOrderItems_ShopOrderItemId",
                table: "ShopOrderItemModifiers",
                column: "ShopOrderItemId",
                principalTable: "ShopOrderItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOrderItems_ShopOrders_ShopOrderId",
                table: "ShopOrderItems",
                column: "ShopOrderId",
                principalTable: "ShopOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOrderItems_ShopProducts_ItemId",
                table: "ShopOrderItems",
                column: "ItemId",
                principalTable: "ShopProducts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOrderPayments_ShopOrders_ShopOrderId",
                table: "ShopOrderPayments",
                column: "ShopOrderId",
                principalTable: "ShopOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopOrders_Users_CreatedById",
                table: "ShopOrders",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProductImages_ShopProductLocalizations_ShopProductLocali~",
                table: "ShopProductImages",
                column: "ShopProductLocalizationId",
                principalTable: "ShopProductLocalizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopProductImages_ShopProducts_ShopProductId",
                table: "ShopProductImages",
                column: "ShopProductId",
                principalTable: "ShopProducts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_LanguageEntities_MainLanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_LanguageEntities_OfficialMainLanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_CountrySites_LanguageEntities_MainLanguageId",
                table: "CountrySites");

            migrationBuilder.DropForeignKey(
                name: "FK_Currencies_LanguageEntities_MainLanguageId",
                table: "Currencies");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocodes_LanguageEntities_MainLanguageId",
                table: "Promocodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductCategories_LanguageEntities_MainLanguageId",
                table: "ShopProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductLocalizations_LanguageEntities_LanguageEntityId",
                table: "ShopProductLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_LanguageEntities_MainLanguageId",
                table: "ShopProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Countries_CountryId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopOrders_Countries_CountryId",
                table: "ShopOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_RegisteredFromCountryId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Promocodes_Availabilities_AvailabilityId",
                table: "Promocodes");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductCategories_Availabilities_AvailabilityId",
                table: "ShopProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_Availabilities_AvailabilityId",
                table: "ShopProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRoleModels_RoleModelId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopOrders_Currencies_CurrencyId",
                table: "ShopOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopOrders_Users_CreatedById",
                table: "ShopOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProducts_PricingMatrices_BasePricingId",
                table: "ShopProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductImages_ShopProducts_ShopProductId",
                table: "ShopProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductLocalizations_ShopProducts_ShopProductId",
                table: "ShopProductLocalizations");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopProductImages_ShopProductLocalizations_ShopProductLocali~",
                table: "ShopProductImages");

            migrationBuilder.DropTable(
                name: "CCWebsiteLocalizationTexts");

            migrationBuilder.DropTable(
                name: "CommonTexts");

            migrationBuilder.DropTable(
                name: "ComplianceDocumentLocalizations");

            migrationBuilder.DropTable(
                name: "ContentAccessModels");

            migrationBuilder.DropTable(
                name: "ContentItems");

            migrationBuilder.DropTable(
                name: "Costs");

            migrationBuilder.DropTable(
                name: "CountryCurrency");

            migrationBuilder.DropTable(
                name: "CountryLanguage");

            migrationBuilder.DropTable(
                name: "CountryLocalizations");

            migrationBuilder.DropTable(
                name: "CurrencyLocalizations");

            migrationBuilder.DropTable(
                name: "EventCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "EventFormatLocalizations");

            migrationBuilder.DropTable(
                name: "EventLocalizations");

            migrationBuilder.DropTable(
                name: "HRLocalizationTexts");

            migrationBuilder.DropTable(
                name: "InvestLocalizationTexts");

            migrationBuilder.DropTable(
                name: "JobSummaries");

            migrationBuilder.DropTable(
                name: "JobVacancyLocalizations");

            migrationBuilder.DropTable(
                name: "LanguageLocalizations");

            migrationBuilder.DropTable(
                name: "MassMediaPostLocalizations");

            migrationBuilder.DropTable(
                name: "OutstaffColumnLocalizations");

            migrationBuilder.DropTable(
                name: "OutstaffItemGradeColumns");

            migrationBuilder.DropTable(
                name: "OutstaffItemGradeLocalizations");

            migrationBuilder.DropTable(
                name: "OutstaffItemLocalizations");

            migrationBuilder.DropTable(
                name: "PartnerLocalizations");

            migrationBuilder.DropTable(
                name: "PortfolioCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "PortfolioIndustryLocalizations");

            migrationBuilder.DropTable(
                name: "PortfolioLocalizations");

            migrationBuilder.DropTable(
                name: "PortfolioLocalizationTexts");

            migrationBuilder.DropTable(
                name: "PostCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "PostIndustryLocalizations");

            migrationBuilder.DropTable(
                name: "PostLocalizations");

            migrationBuilder.DropTable(
                name: "ProductModifierItemLocalizations");

            migrationBuilder.DropTable(
                name: "ProductModifierLocalizations");

            migrationBuilder.DropTable(
                name: "RateVotes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ServicePageFakeReviews");

            migrationBuilder.DropTable(
                name: "ServicePageServiceRibbonItems");

            migrationBuilder.DropTable(
                name: "ServicePageStackIcons");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "ShopLocalizationTexts");

            migrationBuilder.DropTable(
                name: "ShopOrderItemModifierOptions");

            migrationBuilder.DropTable(
                name: "ShopOrderPayments");

            migrationBuilder.DropTable(
                name: "ShopProductCategoryLocalizations");

            migrationBuilder.DropTable(
                name: "ShopWishlistItems");

            migrationBuilder.DropTable(
                name: "SiteVisits");

            migrationBuilder.DropTable(
                name: "StaticPagesLocalizationTexts");

            migrationBuilder.DropTable(
                name: "TeamGroupLocalizations");

            migrationBuilder.DropTable(
                name: "TeamLocalizationTexts");

            migrationBuilder.DropTable(
                name: "TeamMemberLocalizations");

            migrationBuilder.DropTable(
                name: "TimezoneLocalizations");

            migrationBuilder.DropTable(
                name: "UsedPromocodes");

            migrationBuilder.DropTable(
                name: "Watches");

            migrationBuilder.DropTable(
                name: "CCAuthLocalizationTexts");

            migrationBuilder.DropTable(
                name: "CCInfoPageTexts");

            migrationBuilder.DropTable(
                name: "CCMyOrdersPageTexts");

            migrationBuilder.DropTable(
                name: "CCMyProjectsPageTexts");

            migrationBuilder.DropTable(
                name: "CCNotificationsPageTexts");

            migrationBuilder.DropTable(
                name: "CCOrderPageTexts");

            migrationBuilder.DropTable(
                name: "CCProjectPageTexts");

            migrationBuilder.DropTable(
                name: "CCRefLocalizationTexts");

            migrationBuilder.DropTable(
                name: "ClientCabinetCommonTexts");

            migrationBuilder.DropTable(
                name: "FooterTexts");

            migrationBuilder.DropTable(
                name: "HeaderTexts");

            migrationBuilder.DropTable(
                name: "LinksLocalization");

            migrationBuilder.DropTable(
                name: "ComplianceDocuments");

            migrationBuilder.DropTable(
                name: "PricingMatrixItems");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HRJobVacanciesListPageTexts");

            migrationBuilder.DropTable(
                name: "HRJobVacancyPageText");

            migrationBuilder.DropTable(
                name: "InvestProjectPageTexts");

            migrationBuilder.DropTable(
                name: "InvestProjectsListPageTexts");

            migrationBuilder.DropTable(
                name: "MassMediaPosts");

            migrationBuilder.DropTable(
                name: "OutstaffColumns");

            migrationBuilder.DropTable(
                name: "OutstaffItemGrades");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "PortfolioItemPageTexts");

            migrationBuilder.DropTable(
                name: "PortfolioListPageTexts");

            migrationBuilder.DropTable(
                name: "PortfolioStatsPageTexts");

            migrationBuilder.DropTable(
                name: "ServicePageLocalizations");

            migrationBuilder.DropTable(
                name: "ShopBasketPageTexts");

            migrationBuilder.DropTable(
                name: "ShopDeliveryAddressPageTexts");

            migrationBuilder.DropTable(
                name: "ShopItemPageTexts");

            migrationBuilder.DropTable(
                name: "ShopItemsPageTexts");

            migrationBuilder.DropTable(
                name: "ShopOrderNotPaidPageTexts");

            migrationBuilder.DropTable(
                name: "ShopOrderPaidSuccessfullyPageTexts");

            migrationBuilder.DropTable(
                name: "ProductModifierItems");

            migrationBuilder.DropTable(
                name: "ShopOrderItemModifiers");

            migrationBuilder.DropTable(
                name: "ShopWishlists");

            migrationBuilder.DropTable(
                name: "AboutUsPageTexts");

            migrationBuilder.DropTable(
                name: "CorporateCulturePageTexts");

            migrationBuilder.DropTable(
                name: "FindMyAgreementPageTexts");

            migrationBuilder.DropTable(
                name: "FraudCounteractionPageTexts");

            migrationBuilder.DropTable(
                name: "InnerLandingsLocalizationTexts");

            migrationBuilder.DropTable(
                name: "LandingTexts");

            migrationBuilder.DropTable(
                name: "PrivacyPolicyPageTexts");

            migrationBuilder.DropTable(
                name: "ServicesListPageTexts");

            migrationBuilder.DropTable(
                name: "TeamMemberPageTexts");

            migrationBuilder.DropTable(
                name: "TeamPageTexts");

            migrationBuilder.DropTable(
                name: "WebsiteLocalizationTexts");

            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "JobVacancies");

            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "CCAuthCodeSentPageTexts");

            migrationBuilder.DropTable(
                name: "CCAuthRestorePageTexts");

            migrationBuilder.DropTable(
                name: "CCAuthSignInPageTexts");

            migrationBuilder.DropTable(
                name: "CCAuthSignUpPageTexts");

            migrationBuilder.DropTable(
                name: "CCRefAccountPageTexts");

            migrationBuilder.DropTable(
                name: "CCRefMainPageTexts");

            migrationBuilder.DropTable(
                name: "CCRefMyAccountsPageTexts");

            migrationBuilder.DropTable(
                name: "CCRefWithdrawalPageTexts");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropTable(
                name: "EventFormats");

            migrationBuilder.DropTable(
                name: "TimeZones");

            migrationBuilder.DropTable(
                name: "OutstaffItems");

            migrationBuilder.DropTable(
                name: "ServicePages");

            migrationBuilder.DropTable(
                name: "ProductModifiers");

            migrationBuilder.DropTable(
                name: "ShopOrderItems");

            migrationBuilder.DropTable(
                name: "ILQualityAndPipelinePageTexts");

            migrationBuilder.DropTable(
                name: "ILRefProgramPageTexts");

            migrationBuilder.DropTable(
                name: "ILWorkWithUsPageTexts");

            migrationBuilder.DropTable(
                name: "ComplianceTexts");

            migrationBuilder.DropTable(
                name: "EventTexts");

            migrationBuilder.DropTable(
                name: "MassMediaAboutUsTexts");

            migrationBuilder.DropTable(
                name: "OutstaffPageTexts");

            migrationBuilder.DropTable(
                name: "PartnersPageTexts");

            migrationBuilder.DropTable(
                name: "PostsPageTexts");

            migrationBuilder.DropTable(
                name: "ReviewsPageTexts");

            migrationBuilder.DropTable(
                name: "ServicePageTexts");

            migrationBuilder.DropTable(
                name: "SitemapPageTexts");

            migrationBuilder.DropTable(
                name: "TeamGroups");

            migrationBuilder.DropTable(
                name: "JobVacancyExpierences");

            migrationBuilder.DropTable(
                name: "PortfolioCategories");

            migrationBuilder.DropTable(
                name: "PortfolioIndustries");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "PostIndustries");

            migrationBuilder.DropTable(
                name: "OutstaffMatrices");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "TeamStructures");

            migrationBuilder.DropTable(
                name: "LanguageEntities");

            migrationBuilder.DropTable(
                name: "CountrySites");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Availabilities");

            migrationBuilder.DropTable(
                name: "UserRoleModels");

            migrationBuilder.DropTable(
                name: "HRAccessModels");

            migrationBuilder.DropTable(
                name: "OutstaffAccessModels");

            migrationBuilder.DropTable(
                name: "ReviewsAccessModels");

            migrationBuilder.DropTable(
                name: "ShopAccessModels");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BanInfos");

            migrationBuilder.DropTable(
                name: "ShopOrders");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Promocodes");

            migrationBuilder.DropTable(
                name: "ShopOrderReturns");

            migrationBuilder.DropTable(
                name: "PricingMatrices");

            migrationBuilder.DropTable(
                name: "ShopProducts");

            migrationBuilder.DropTable(
                name: "ShopProductCategories");

            migrationBuilder.DropTable(
                name: "ShopProductLocalizations");

            migrationBuilder.DropTable(
                name: "ShopProductImages");
        }
    }
}
