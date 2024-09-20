using Alfateam.DB.Helpers;
using Alfateam.Website.API.Helpers;
using Alfateam2._0.Models;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.Enums;
using Alfateam2._0.Models.Events;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.HR;
using Alfateam2._0.Models.Localization.General;
using Alfateam2._0.Models.Localization.Items;
using Alfateam2._0.Models.Localization.Items.Events;
using Alfateam2._0.Models.Localization.Items.HR;
using Alfateam2._0.Models.Localization.Items.Portfolios;
using Alfateam2._0.Models.Localization.Items.Posts;
using Alfateam2._0.Models.Localization.Items.Shop;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;
using Alfateam2._0.Models.Localization.Items.Team;
using Alfateam2._0.Models.Localization.Outstaff;
using Alfateam2._0.Models.Localization.Texts;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Auth;
using Alfateam2._0.Models.Localization.Texts.ClientCabinet.Referral;
using Alfateam2._0.Models.Localization.Texts.Common;
using Alfateam2._0.Models.Localization.Texts.Grouping;
using Alfateam2._0.Models.Localization.Texts.Grouping.ClientCabinet;
using Alfateam2._0.Models.Localization.Texts.Grouping.StaticPages;
using Alfateam2._0.Models.Localization.Texts.HR;
using Alfateam2._0.Models.Localization.Texts.Invest;
using Alfateam2._0.Models.Localization.Texts.Portfolio;
using Alfateam2._0.Models.Localization.Texts.Shop;
using Alfateam2._0.Models.Localization.Texts.StaticPages;
using Alfateam2._0.Models.Localization.Texts.StaticPages.InnerLandings;
using Alfateam2._0.Models.Localization.Texts.Team;
using Alfateam2._0.Models.Outstaff;
using Alfateam2._0.Models.Portfolios;
using Alfateam2._0.Models.Posts;
using Alfateam2._0.Models.Promocodes;
using Alfateam2._0.Models.Reviews;
using Alfateam2._0.Models.Roles;
using Alfateam2._0.Models.Roles.Access;
using Alfateam2._0.Models.ServicePages;
using Alfateam2._0.Models.Shop;
using Alfateam2._0.Models.Shop.Modifiers;
using Alfateam2._0.Models.Shop.Modifiers.Items;
using Alfateam2._0.Models.Shop.Orders;
using Alfateam2._0.Models.Shop.Wishes;
using Alfateam2._0.Models.Stats;
using Alfateam2._0.Models.Team;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.DB
{
    public class WebsiteDBContext : DbContext
    {
        public WebsiteDBContext()
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;

            Database.EnsureCreated();
            MakeDefaultEntities();

            //if (Database.EnsureCreated())
            //{
            //    MakeDefaultEntities();
            //} 
        }
        public WebsiteDBContext(DbContextOptions<WebsiteDBContext> options)
        {

            Database.EnsureCreated();
            MakeDefaultEntities();

            //if (Database.EnsureCreated())
            //{
            //    MakeDefaultEntities();
            //}
        }




        #region Abstractions
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<ProductModifierItem> ProductModifierItems { get; set; }
        public DbSet<Promocode> Promocodes { get; set; }

        #endregion

        #region Events
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventFormat> EventFormats { get; set; }
        #endregion

        #region General
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Availability> Availabilities { get; set; }
        public DbSet<BanInfo> BanInfos { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountrySite> CountrySites { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PricingMatrix> PricingMatrices { get; set; }
        public DbSet<PricingMatrixItem> PricingMatrixItems { get; set; }
        public DbSet<RateVote> RateVotes { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Alfateam2._0.Models.General.TimeZone> TimeZones { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Watch> Watches { get; set; }
        #endregion

        #region HR
        public DbSet<JobSummary> JobSummaries { get; set; }
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobVacancyExpierence> JobVacancyExpierences { get; set; }
        #endregion

        #region Localization

        #region General
        public DbSet<CountryLocalization> CountryLocalizations { get; set; }
        public DbSet<CurrencyLocalization> CurrencyLocalizations { get; set; }
        public DbSet<LanguageLocalization> LanguageLocalizations { get; set; }
        public DbSet<TimezoneLocalization> TimezoneLocalizations { get; set; }

        #endregion

        #region Items

        #region Events
        public DbSet<EventCategoryLocalization> EventCategoryLocalizations { get; set; }
        public DbSet<EventFormatLocalization> EventFormatLocalizations { get; set; }
        public DbSet<EventLocalization> EventLocalizations { get; set; }
        #endregion

        #region HR
        public DbSet<JobVacancyLocalization> JobVacancyLocalizations { get; set; }
        #endregion

        #region Portfolios
        public DbSet<PortfolioCategoryLocalization> PortfolioCategoryLocalizations { get; set; }
        public DbSet<PortfolioIndustryLocalization> PortfolioIndustryLocalizations { get; set; }
        public DbSet<PortfolioLocalization> PortfolioLocalizations { get; set; }
        #endregion

        #region Posts
        public DbSet<PostCategoryLocalization> PostCategoryLocalizations { get; set; }
        public DbSet<PostIndustryLocalization> PostIndustryLocalizations { get; set; }
        public DbSet<PostLocalization> PostLocalizations { get; set; }
        #endregion

        #region Shop

        #region Modifiers
        public DbSet<ProductModifierItemLocalization> ProductModifierItemLocalizations { get; set; }
        public DbSet<ProductModifierLocalization> ProductModifierLocalizations { get; set; }
        #endregion

        public DbSet<ShopProductCategoryLocalization> ShopProductCategoryLocalizations { get; set; }
        public DbSet<ShopProductLocalization> ShopProductLocalizations { get; set; }
        #endregion

        #region Team
        public DbSet<TeamGroupLocalization> TeamGroupLocalizations { get; set; }
        public DbSet<TeamMemberLocalization> TeamMemberLocalizations { get; set; }
        #endregion

        public DbSet<ComplianceDocumentLocalization> ComplianceDocumentLocalizations { get; set; }
        public DbSet<MassMediaPostLocalization> MassMediaPostLocalizations { get; set; }
        public DbSet<PartnerLocalization> PartnerLocalizations { get; set; }
        public DbSet<ServicePageLocalization> ServicePageLocalizations { get; set; }
        
        #endregion

        #region Outstaff
        public DbSet<OutstaffColumnLocalization> OutstaffColumnLocalizations { get; set; }
        public DbSet<OutstaffItemGradeLocalization> OutstaffItemGradeLocalizations { get; set; }
        public DbSet<OutstaffItemLocalization> OutstaffItemLocalizations { get; set; }
        #endregion

        #region Texts

        #region ClientCabinet

        #region Auth
        public DbSet<CCAuthCodeSentPageTexts> CCAuthCodeSentPageTexts { get; set; }
        public DbSet<CCAuthRestorePageTexts> CCAuthRestorePageTexts { get; set; }
        public DbSet<CCAuthSignInPageTexts> CCAuthSignInPageTexts { get; set; }
        public DbSet<CCAuthSignUpPageTexts> CCAuthSignUpPageTexts { get; set; }

        #endregion

        #region Referral
        public DbSet<CCRefAccountPageTexts> CCRefAccountPageTexts { get; set; }
        public DbSet<CCRefMainPageTexts> CCRefMainPageTexts { get; set; }
        public DbSet<CCRefMyAccountsPageTexts> CCRefMyAccountsPageTexts { get; set; }
        public DbSet<CCRefWithdrawalPageTexts> CCRefWithdrawalPageTexts { get; set; }

        #endregion

        public DbSet<CCInfoPageTexts> CCInfoPageTexts { get; set; }
        public DbSet<CCMyOrdersPageTexts> CCMyOrdersPageTexts { get; set; }
        public DbSet<CCMyProjectsPageTexts> CCMyProjectsPageTexts { get; set; }
        public DbSet<CCNotificationsPageTexts> CCNotificationsPageTexts { get; set; }
        public DbSet<CCOrderPageTexts> CCOrderPageTexts { get; set; }
        public DbSet<CCProjectPageTexts> CCProjectPageTexts { get; set; }

        #endregion

        #region Common
        public DbSet<ClientCabinetCommonTexts> ClientCabinetCommonTexts { get; set; }
        public DbSet<FooterTexts> FooterTexts { get; set; }
        public DbSet<HeaderTexts> HeaderTexts { get; set; }
        public DbSet<LinksLocalization> LinksLocalization { get; set; }

        #endregion

        #region Grouping

        #region ClientCabinet
        public DbSet<CCAuthLocalizationTexts> CCAuthLocalizationTexts { get; set; }
        public DbSet<CCRefLocalizationTexts> CCRefLocalizationTexts { get; set; }
        public DbSet<CCWebsiteLocalizationTexts> CCWebsiteLocalizationTexts { get; set; }

        #endregion

        #region StaticPages
        public DbSet<InnerLandingsLocalizationTexts> InnerLandingsLocalizationTexts { get; set; }
        public DbSet<StaticPagesLocalizationTexts> StaticPagesLocalizationTexts { get; set; }

        #endregion

        public DbSet<CommonTexts> CommonTexts { get; set; }
        public DbSet<HRLocalizationTexts> HRLocalizationTexts { get; set; }
        public DbSet<InvestLocalizationTexts> InvestLocalizationTexts { get; set; }
        public DbSet<PortfolioLocalizationTexts> PortfolioLocalizationTexts { get; set; }
        public DbSet<ShopLocalizationTexts> ShopLocalizationTexts { get; set; }
        public DbSet<TeamLocalizationTexts> TeamLocalizationTexts { get; set; }
        public DbSet<WebsiteLocalizationTexts> WebsiteLocalizationTexts { get; set; }

        #endregion

        #region HR
        public DbSet<HRJobVacanciesListPageTexts> HRJobVacanciesListPageTexts { get; set; }
        public DbSet<HRJobVacancyPageText> HRJobVacancyPageText { get; set; }

        #endregion

        #region Invest
        public DbSet<InvestProjectPageTexts> InvestProjectPageTexts { get; set; }
        public DbSet<InvestProjectsListPageTexts> InvestProjectsListPageTexts { get; set; }

        #endregion

        #region Portfolio
        public DbSet<PortfolioItemPageTexts> PortfolioItemPageTexts { get; set; }
        public DbSet<PortfolioListPageTexts> PortfolioListPageTexts { get; set; }
        public DbSet<PortfolioStatsPageTexts> PortfolioStatsPageTexts { get; set; }

        #endregion

        #region Shop
        public DbSet<ShopBasketPageTexts> ShopBasketPageTexts { get; set; }
        public DbSet<ShopDeliveryAddressPageTexts> ShopDeliveryAddressPageTexts { get; set; }
        public DbSet<ShopItemPageTexts> ShopItemPageTexts { get; set; }
        public DbSet<ShopItemsPageTexts> ShopItemsPageTexts { get; set; }
        public DbSet<ShopOrderNotPaidPageTexts> ShopOrderNotPaidPageTexts { get; set; }
        public DbSet<ShopOrderPaidSuccessfullyPageTexts> ShopOrderPaidSuccessfullyPageTexts { get; set; }

        #endregion

        #region StaticPages

        #region InnerLandings
        public DbSet<ILQualityAndPipelinePageTexts> ILQualityAndPipelinePageTexts { get; set; }
        public DbSet<ILRefProgramPageTexts> ILRefProgramPageTexts { get; set; }
        public DbSet<ILWorkWithUsPageTexts> ILWorkWithUsPageTexts { get; set; }

        #endregion

        public DbSet<AboutUsPageTexts> AboutUsPageTexts { get; set; }
        public DbSet<CorporateCulturePageTexts> CorporateCulturePageTexts { get; set; }
        public DbSet<FindMyAgreementPageTexts> FindMyAgreementPageTexts { get; set; }
        public DbSet<FraudCounteractionPageTexts> FraudCounteractionPageTexts { get; set; }
        public DbSet<LandingTexts> LandingTexts { get; set; }
        public DbSet<PrivacyPolicyPageTexts> PrivacyPolicyPageTexts { get; set; }
        public DbSet<ServicesListPageTexts> ServicesListPageTexts { get; set; }

        #endregion

        #region Team
        public DbSet<TeamMemberPageTexts> TeamMemberPageTexts { get; set; }
        public DbSet<TeamPageTexts> TeamPageTexts { get; set; }

        #endregion

        public DbSet<ComplianceTexts> ComplianceTexts { get; set; }
        public DbSet<EventTexts> EventTexts { get; set; }
        public DbSet<MassMediaAboutUsTexts> MassMediaAboutUsTexts { get; set; }
        public DbSet<OutstaffPageTexts> OutstaffPageTexts { get; set; }
        public DbSet<PartnersPageTexts> PartnersPageTexts { get; set; }
        public DbSet<PostsPageTexts> PostsPageTexts { get; set; }
        public DbSet<ReviewsPageTexts> ReviewsPageTexts { get; set; }
        public DbSet<ServicePageTexts> ServicePageTexts { get; set; }
        public DbSet<SitemapPageTexts> SitemapPageTexts { get; set; }

        #endregion

        #endregion

        #region Outstaff
        public DbSet<OutstaffColumn> OutstaffColumns { get; set; }
        public DbSet<OutstaffItem> OutstaffItems { get; set; }
        public DbSet<OutstaffItemGrade> OutstaffItemGrades { get; set; }
        public DbSet<OutstaffItemGradeColumn> OutstaffItemGradeColumns { get; set; }
        public DbSet<OutstaffMatrix> OutstaffMatrices { get; set; }
        #endregion

        #region Portfolios
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<PortfolioIndustry> PortfolioIndustries { get; set; }
        #endregion

        #region Posts
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostIndustry> PostIndustries { get; set; }
        #endregion

        #region Promocodes
        public DbSet<UsedPromocode> UsedPromocodes { get; set; }
        #endregion

        #region Reviews
        public DbSet<Review> Reviews { get; set; }
        #endregion

        #region Roles

        #region Access
        public DbSet<ContentAccessModel> ContentAccessModels { get; set; }
        public DbSet<HRAccessModel> HRAccessModels { get; set; }
        public DbSet<OutstaffAccessModel> OutstaffAccessModels { get; set; }
        public DbSet<ReviewsAccessModel> ReviewsAccessModels { get; set; }
        public DbSet<ShopAccessModel> ShopAccessModels { get; set; }

        #endregion

        public DbSet<UserRoleModel> UserRoleModels { get; set; }

        #endregion

        #region ServicePages
        public DbSet<ServicePage> ServicePages { get; set; }
        public DbSet<ServicePageFakeReview> ServicePageFakeReviews { get; set; }
        public DbSet<ServicePageServiceRibbonItem> ServicePageServiceRibbonItems { get; set; }
        public DbSet<ServicePageStackIcon> ServicePageStackIcons { get; set; }
        #endregion

        #region Shop

        #region Modifiers
        public DbSet<ProductModifier> ProductModifiers { get; set; }
        #endregion

        #region Orders
        public DbSet<ShopOrder> ShopOrders { get; set; }
        public DbSet<ShopOrderItem> ShopOrderItems { get; set; }
        public DbSet<ShopOrderItemModifier> ShopOrderItemModifiers { get; set; }
        public DbSet<ShopOrderItemModifierOption> ShopOrderItemModifierOptions { get; set; }
        public DbSet<ShopOrderPayment> ShopOrderPayments { get; set; }
        public DbSet<ShopOrderReturn> ShopOrderReturns { get; set; }
        #endregion

        #region Wishes
        public DbSet<ShopWishlist> ShopWishlists { get; set; }
        public DbSet<ShopWishlistItem> ShopWishlistItems { get; set; }
        #endregion

        public DbSet<ShopProduct> ShopProducts { get; set; }
        public DbSet<ShopProductCategory> ShopProductCategories { get; set; }
        public DbSet<ShopProductImage> ShopProductImages { get; set; }
        #endregion

        #region Stats
        public DbSet<SiteVisit> SiteVisits { get; set; }

        #endregion

        #region Team
        public DbSet<TeamGroup> TeamGroups { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamStructure> TeamStructures { get; set; }
        #endregion

        public DbSet<ComplianceDocument> ComplianceDocuments { get; set; }
        public DbSet<MassMediaPost> MassMediaPosts { get; set; }
        public DbSet<Partner> Partners { get; set; }



        #region Initial methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStrings.Website, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Abstract ContentItem
            modelBuilder.Entity<AudioContentItem>();
            modelBuilder.Entity<ImageContentItem>();
            modelBuilder.Entity<ImageSliderContentItem>();
            modelBuilder.Entity<TextContentItem>();
            modelBuilder.Entity<VideoContentItem>();

            //Abstract Promocode
            modelBuilder.Entity<Promocode>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<PricePromocode>();
            modelBuilder.Entity<PercentPromocode>();

            //Abstract ProductModifierItem
            modelBuilder.Entity<ProductModifierItem>().HasDiscriminator(b => b.Discriminator);
            modelBuilder.Entity<ColorModifierItem>();
            modelBuilder.Entity<SimpleModifierItem>();


            modelBuilder.Entity<Country>().HasMany(o => o.Languages).WithMany(o => o.CountryManyToManyRefs);
            modelBuilder.Entity<Country>().HasMany(o => o.Currencies).WithMany(o => o.CountryManyToManyRefs);
            modelBuilder.Entity<Country>().HasOne(o => o.MainCurrency);
            modelBuilder.Entity<Country>().HasOne(o => o.MainLanguage);
            modelBuilder.Entity<Country>().HasOne(o => o.OfficialMainLanguage);

            modelBuilder.Entity<Language>().HasMany(o => o.Localizations).WithOne(o => o.LanguageMainModel);


            modelBuilder.Entity<User>().HasOne(o => o.Basket);
            modelBuilder.Entity<User>().HasMany(o => o.Orders).WithOne(o => o.CreatedBy);
            modelBuilder.Entity<User>().HasOne(o => o.Wishlist);

          



            //modelBuilder.Entity<ShopWishlist>().HasOne(o => o.User).WithOne(o => o.Wishlist);

            //modelBuilder.Entity<Language>().HasOne(o => o.Localizations).
        }

        #endregion

        #region Make default entities methods

        private void MakeDefaultEntities()
        {
            try
            {
                MakeDefaultLanguages();
                SaveChanges();


                MakeDefaultCurrencies();
                SaveChanges();

                MakeDefaultCountries();

                MakeDefaultUsers();

                SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }


        private void MakeDefaultLanguages()
        {
            if (Languages.Any()) return;

            var russian = new Language
            {
                Title = "Русский",
                Code = "RU",
         
            };
            //russian.MainLanguage = russian;

            var kazakh = new Language
            {
                Title = "Казахский",
                Code = "KZ",
                MainLanguage = russian,
                IsHidden = true,
            };

            var kyrgyz = new Language
            {
                Title = "Кыргызский",
                Code = "KG",
                MainLanguage = russian,
                IsHidden = true
            };

            var english = new Language
            {
                Title = "Английский",
                Code = "EN",
                MainLanguage = russian,
                IsHidden = true
            };

            var mongolian = new Language
            {
                Title = "Монгольский",
                Code = "MN",
                MainLanguage = russian,
                IsHidden = true
            };

            Languages.AddRange(russian, kazakh, kyrgyz, english, mongolian);
        }
        private void MakeDefaultCurrencies()
        {
            if (Currencies.Any()) return;

            var rusMainLang = Languages.FirstOrDefault(o => o.Code == "RU");

            var russianRuble = new Currency("Российский рубль", "RUB", "₽")
            {
                MainLanguage = rusMainLang,
            };
            var kazakhTenge = new Currency("Казахстанский тенге", "KZT", "₸")
            {
                MainLanguage = rusMainLang
            };
            var usDollar = new Currency("Доллар США", "USD", "$")
            {
                MainLanguage = rusMainLang
            };
            var euro = new Currency("Евро", "EUR", "€")
            {
                MainLanguage = rusMainLang
            };
            var mongolianTugrik = new Currency("Монгольский тугрик", "MNT", "₮")
            {
                MainLanguage = rusMainLang
            };
            var kyrgyzSom = new Currency("Кыргызстанский сом", "KGS", "⃀")
            {
                MainLanguage = rusMainLang
            };

            Currencies.AddRange(russianRuble, kazakhTenge, usDollar, euro, mongolianTugrik, kyrgyzSom);
        }
        private void MakeDefaultCountries()
        {
            if (Countries.Any()) return;

            var rusMainLang = Languages.FirstOrDefault(o => o.Code == "RU");
            var kazLang = Languages.FirstOrDefault(o => o.Code == "KZ");
            var kyrgyzLang = Languages.FirstOrDefault(o => o.Code == "KG");
            var mongolianLang = Languages.FirstOrDefault(o => o.Code == "MN");

            var rusRuble = Currencies.FirstOrDefault(o => o.Code == "RUB");
            var kazTenge = Currencies.FirstOrDefault(o => o.Code == "KZT");
            var kyrgyzSom = Currencies.FirstOrDefault(o => o.Code == "KGS");
            var mongTugrik = Currencies.FirstOrDefault(o => o.Code == "MNT");
            var usDollar = Currencies.FirstOrDefault(o => o.Code == "USD");

            var russia = new Country("Россия", "RU")
            {
                MainLanguage = rusMainLang,
                OfficialMainLanguage = rusMainLang,
                Languages = new List<Language> { rusMainLang},
                MainCurrency = rusRuble,
                Currencies = new List<Currency> { rusRuble },
            };
            var kazakhstan = new Country("Казахстан", "KZ")
            {
                MainLanguage = rusMainLang,
                OfficialMainLanguage = kazLang,
                Languages = new List<Language> { rusMainLang, kazLang },
                MainCurrency = kazTenge,
                Currencies = new List<Currency> { kazTenge },
            };
            var kyrgyzstan = new Country("Кыргызстан", "KG")
            {
                MainLanguage = rusMainLang,
                OfficialMainLanguage = kyrgyzLang,
                Languages = new List<Language> { rusMainLang, kyrgyzLang },
                MainCurrency = kyrgyzSom,
                Currencies = new List<Currency> { kyrgyzSom, usDollar },
            };
            var mongolia = new Country("Монголия", "MN")
            {
                MainLanguage = rusMainLang,
                OfficialMainLanguage = mongolianLang,
                Languages = new List<Language> { mongolianLang },
                MainCurrency = mongTugrik,
                Currencies = new List<Currency> { mongTugrik, usDollar },
            };

            Countries.AddRange(russia, kazakhstan, kyrgyzstan, mongolia);
        }

        private void MakeDefaultUsers()
        {
            if (Users.Any()) return;

            var owner = new User()
            {
                RoleModel = UserRoleModel.CreateDefault(),
                Email = "alfateamkz@yandex.kz",
                Name = "Артур",
                Surname = "Бондарев",
                Patronymic = "Александрович",
                Password = PasswordHelper.EncryptPassword("alfateam2_0!2023"),
            };
            owner.RoleModel.Role = UserRole.Owner;
            owner.RoleModel.IsAllCountriesAccess = true;

            var magzum = new User()
            {
                RoleModel = UserRoleModel.CreateDefault(),
                Email = "magzhumtop@yandex.kz",
                Name = "Мағзұм",
                Surname = "Жаңабергенов",
                Patronymic = "Өтегенұлы",
                Password = PasswordHelper.EncryptPassword("magzhumtop_2022"),
            };
            magzum.RoleModel.Role = UserRole.Owner;
            magzum.RoleModel.IsAllCountriesAccess = true;

            Users.AddRange(owner, magzum);
        }

        #endregion

        #region Public methods






        public Availability GetIncludedAvailability(int id)
        {
            return this.Availabilities.Include(o => o.AllowedCountries)
                                      .Include(o => o.DisallowedCountries)
                                      .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        }
        public PricingMatrix GetIncludedPricingMatrix(int id)
        {
            return this.PricingMatrices.Include(o => o.Costs).ThenInclude(o => o.Country)
                                       .Include(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                       .FirstOrDefault(o => o.Id == id && !o.IsDeleted);
        }

        public OutstaffMatrix GetOutstaffMatrix()
        {
            var found = OutstaffMatrices.Include(o => o.Columns).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Items).ThenInclude(o => o.Grades).ThenInclude(o => o.Prices).ThenInclude(o => o.CostPerHour).ThenInclude(o => o.Costs).ThenInclude(o => o.Country)
                                        .Include(o => o.Items).ThenInclude(o => o.Grades).ThenInclude(o => o.Prices).ThenInclude(o => o.CostPerHour).ThenInclude(o => o.Costs).ThenInclude(o => o.Costs).ThenInclude(o => o.Currency)
                                        .Include(o => o.Items).ThenInclude(o => o.Grades).ThenInclude(o => o.Prices).ThenInclude(o => o.Column).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Items).ThenInclude(o => o.Grades).ThenInclude(o => o.Localizations)
                                        .Include(o => o.Items).ThenInclude(o => o.Localizations)
                                        .FirstOrDefault();

            if(found == null)
            {
                found = new OutstaffMatrix();
                OutstaffMatrices.Add(found);
                SaveChanges();
            }

            return found;
        }

        #endregion




    }
}
