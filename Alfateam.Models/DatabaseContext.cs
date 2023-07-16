using Alfateam.Database.Helpers;
using Alfateam.Database.Models;
using Alfateam.Database.Models.Abstractions;
using Alfateam.Database.Models.CRM;
using Alfateam.Database.Models.CRM.Accounting;
using Alfateam.Database.Models.CRM.Orders;
using Alfateam.Database.Models.CRM.Sales;
using Alfateam.Database.Models.CRM.Staff;
using Alfateam.Database.Models.ForBusiness;
using Alfateam.Database.Models.General;
using Alfateam.Database.Models.Localizations;
using Alfateam.Database.Models.Localizations.Texts;
using Alfateam.Database.Models.Localizations.Texts.OtherPages;
using Alfateam.Database.Models.Localizations.Texts.Popups;
using Alfateam.Database.Models.NewPosts;
using Alfateam.Database.Models.Portfolios;
using Alfateam.Database.Models.Promotions;
using Alfateam.Database.Models.SitePagesTexts;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<SiteFrontend> SiteFrontends { get; set; }

        public DbSet<Post> Posts { get; set; }

        #region NewPosts
        public DbSet<NewPost> NewPosts { get; set; }
        public DbSet<PostHeading> PostHeadings { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<PostParagraph> PostParagraphs { get; set; }
        public DbSet<PostSlider> PostSliders { get; set; }
        public DbSet<PostVideo> PostVideos { get; set; }

        #endregion

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CallRequest> CallRequests { get; set; }
        public DbSet<PortfolioCategory> PortfolioCategories { get; set; }
        public DbSet<Teammate> Teammates { get; set; }



        #region SitePagesTexts
        public DbSet<ErrorPages> ErrorPages { get; set; }
        public DbSet<GeneralTexts> GeneralTexts { get; set; }
        public DbSet<LandingTexts> LandingTexts { get; set; }
        #endregion

        #region Promotions
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionDescriptionItem> PromotionDescriptionItems { get; set; }
        #endregion

        #region Portfolios
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<PortfolioImage> PortfolioImages { get; set; }
		#endregion

		#region ForBusiness
		public DbSet<OutstaffEmployeeInfo> OutstaffEmployeeInfos { get; set; }
		#endregion

		#region General
		public DbSet<Language> Languages { get; set; }
        public DbSet<TranslationItem> TranslationItems { get; set; }
        public DbSet<UserModel> Users { get; set; }
        #endregion


        #region Localizations

        #region Texts

        #region Other pages
        public DbSet<NewsPageLocalization> NewsPageLocalizations { get; set; }
        public DbSet<PortfolioPageLocalization> PortfolioPageLocalizations { get; set; }
        public DbSet<PrivacyPageLocalization> PrivacyPageLocalizations { get; set; }
        public DbSet<ServicesPageLocalization> ServicesPageLocalizations { get; set; }
        #endregion

        #region Popups
        public DbSet<AcceptOrderPopupLocalization> AcceptOrderPopupLocalizations { get; set; }
        public DbSet<CallPopupLocalization> CallPopupLocalizations { get; set; }
        public DbSet<ContactsPopupLocalization> ContactsPopupLocalizations { get; set; }
        public DbSet<PortfolioPopupLocalization> PortfolioPopupLocalizations { get; set; }
        #endregion

        public DbSet<CalculatorLocalization> CalculatorLocalizations { get; set; }
        public DbSet<ErrorPagesLocalization> ErrorPagesLocalizations { get; set; }
        public DbSet<MainPageLocalization> MainPageLocalizations { get; set; }
        public DbSet<MapBlockLocalization> MapBlockLocalizations { get; set; }
        public DbSet<SharedLocalization> SharedLocalizations { get; set; }
        #endregion

        public DbSet<PartnerLocalization> PartnerLocalizations { get; set; }
        public DbSet<PortfolioCategoryLocalization> PortfolioCategoryLocalizations { get; set; }
        public DbSet<PortfolioLocalization> PortfolioLocalizations { get; set; }
        public DbSet<PromotionDescriptionItemLocalization> PromotionDescriptionItemLocalizations { get; set; }
        public DbSet<PromotionLocalization> PromotionLocalizations { get; set; }
        public DbSet<TeammateLocalization> TeammateLocalizations { get; set; }
        #endregion

        public DatabaseContext() : base()
        {
            Database.Migrate();

            if (SiteFrontends.Count() == 0)
            {
                FillLanguages();
                SaveChanges();


                FillSiteTexts();
                SaveChanges();
            }

            if (!SharedLocalizations.Any())
            {
                FillRussianLocalization();
                SaveChanges();
            }
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        {
            Database.Migrate();



            if (SiteFrontends.Count() == 0)
            {
                FillUsers();

                FillLanguages();
                SaveChanges();


                FillSiteTexts();
                SaveChanges();
            }



            if (!SharedLocalizations.Any())
            {
                try
                {
                    FillRussianLocalization();
                    SaveChanges();
                }
                catch (Exception ex)
                {

                }
            }
        }

        #region Fill DB Methods
        private void FillLanguages()
        {
            Languages.Add(new Language
            {
                Title = "Русский",
                Code = "RU",
                IconPath = ""
            });
            Languages.Add(new Language
            {
                Title = "Қазақша",
                Code = "KZ",
                IconPath = ""
            });
            Languages.Add(new Language
            {
                Title = "Татарча",
                Code = "TT",
                IconPath = ""
            });
            Languages.Add(new Language
            {
                Title = "English",
                Code = "EN",
                IconPath = ""
            });

        }
        private void FillSiteTexts()
        {
            var frontend = new SiteFrontend();

            var errorTexts = new ErrorPages();
            errorTexts.Texts404.Add(new TranslationItem { LanguageId = 1, Text = "Страница не найдена" });
            errorTexts.Texts403.Add(new TranslationItem { LanguageId = 1, Text = "Доступ запрещен :(" });
            errorTexts.TextsNuhuyaTitle.Add(new TranslationItem { LanguageId = 1, Text = "ЗДЕСЬ НИХУЯ НЕТ" });
            errorTexts.TextsNuhuyaDescription.Add(new TranslationItem { LanguageId = 1, Text = "Если ты что-то искал, то здесь такого нет :(" });


            var generalTexts = new GeneralTexts();
            generalTexts.Main.Add(new TranslationItem { LanguageId = 1, Text = "Главная" });
            generalTexts.ServicesPrice.Add(new TranslationItem { LanguageId = 1, Text = "Стоимость услуг" });
            generalTexts.OurWorks.Add(new TranslationItem { LanguageId = 1, Text = "Наши работы" });
            generalTexts.News.Add(new TranslationItem { LanguageId = 1, Text = "Новости" });
            generalTexts.Partners.Add(new TranslationItem { LanguageId = 1, Text = "Партнеры" });
            generalTexts.Team.Add(new TranslationItem { LanguageId = 1, Text = "Команда" });

            generalTexts.Navigation.Add(new TranslationItem { LanguageId = 1, Text = "НАВИГАЦИЯ" });
            generalTexts.Contacts.Add(new TranslationItem { LanguageId = 1, Text = "Контакты" });
            generalTexts.SocialNetworks.Add(new TranslationItem { LanguageId = 1, Text = "СОЦИАЛЬНЫЕ СЕТИ" });
            generalTexts.AllRightsReserved.Add(new TranslationItem { LanguageId = 1, Text = "Все права защищены" });


            generalTexts.PublishedAt.Add(new TranslationItem { LanguageId = 1, Text = "Опубликовано" });
            generalTexts.Close.Add(new TranslationItem { LanguageId = 1, Text = "Закрыть" });
            generalTexts.Categories.Add(new TranslationItem { LanguageId = 1, Text = "Категории" });
            generalTexts.AddedAt.Add(new TranslationItem { LanguageId = 1, Text = "Дата добавления" });
            generalTexts.Watches.Add(new TranslationItem { LanguageId = 1, Text = "просмотров" });
            generalTexts.AllPortfolios.Add(new TranslationItem { LanguageId = 1, Text = "Все портфолио" });
            generalTexts.NewPortfolioLabel.Add(new TranslationItem { LanguageId = 1, Text = "Новое!" });

            var landingTexts = new LandingTexts();
            landingTexts.StartBusiness.Add(new TranslationItem { LanguageId = 1, Text = "ЗАПУСТИ СВОЙ НОВЫЙ БИЗНЕС С ALPHA TEAM" });
            landingTexts.StartBusinessDescriptions.Add(new TranslationItem { LanguageId = 1, Text = "Хотите реализовать свой проект в самые короткие сроки с минимальным бюджетом? Теперь это можно сделать с нами!" });
            landingTexts.OrderNow.Add(new TranslationItem { LanguageId = 1, Text = "Заказать сейчас" });

            landingTexts.WeAcceptPayments.Add(new TranslationItem { LanguageId = 1, Text = "Мы принимаем" });

            landingTexts.OurPortfolios.Add(new TranslationItem { LanguageId = 1, Text = "НАШИ РАБОТЫ" });
            landingTexts.OurLastPortfolios.Add(new TranslationItem { LanguageId = 1, Text = "Последние выполненые заказы" });
            landingTexts.MorePortfolios.Add(new TranslationItem { LanguageId = 1, Text = "Больше работ" });

            landingTexts.News.Add(new TranslationItem { LanguageId = 1, Text = "НОВОСТИ" });
            landingTexts.DiscoverNews.Add(new TranslationItem { LanguageId = 1, Text = "Узнавайте о последних новостях" });
            landingTexts.NewsDetails.Add(new TranslationItem { LanguageId = 1, Text = "Подробнее" });
            landingTexts.NewsMore.Add(new TranslationItem { LanguageId = 1, Text = "БОЛЬШЕ НОВОСТЕЙ" });

            landingTexts.Order.Add(new TranslationItem { LanguageId = 1, Text = "ЗАЯВКА" });
            landingTexts.MakeOrder.Add(new TranslationItem { LanguageId = 1, Text = "Оставьте заявку и мы вам ответим." });
            landingTexts.YourName.Add(new TranslationItem { LanguageId = 1, Text = "Как к Вам обращаться?" });
            landingTexts.CompanyName.Add(new TranslationItem { LanguageId = 1, Text = "Название вашей компании" });
            landingTexts.DescribeJob.Add(new TranslationItem { LanguageId = 1, Text = "Опишите задачу" });
            landingTexts.DescribeJobPlaceholder.Add(new TranslationItem { LanguageId = 1, Text = "Я хочу  сервер в майнкрафте с шлюхами и водкой" });
            landingTexts.YourBudget.Add(new TranslationItem { LanguageId = 1, Text = "Ваш бюджет" });
            landingTexts.Contacts.Add(new TranslationItem { LanguageId = 1, Text = "Контакты для связи" });
            landingTexts.ContactsPlaceholder.Add(new TranslationItem { LanguageId = 1, Text = "Номер телефона, E-mail" });
            landingTexts.Send.Add(new TranslationItem { LanguageId = 1, Text = "Отправить" });
            landingTexts.OrderCompleted.Add(new TranslationItem { LanguageId = 1, Text = "Ваша заявка принята" });


            frontend.ErrorPages = errorTexts;
            frontend.GeneralTexts = generalTexts;
            frontend.LandingTexts = landingTexts;

            SiteFrontends.Add(frontend);
        }
        private void FillUsers()
        {
            Users.Add(new UserModel
            {
                Email = "aynaz@mail.ru",
                Password = "123456",
                Name = "Айназ",
                Surname = "Кондудаева",
                UserRole = Enums.UserRole.Admin
            });
            Users.Add(new UserModel
            {
                Email = "kachokabricosyan@gmail.com",
                Password = "228228vV",
                Name = "Артұр",
                Surname = "Бондарев",
                UserRole = Enums.UserRole.Admin
            });
        }

        private void FillRussianLocalization()
        {
            //Текста по умолчанию заданы
            //LanguageId = 1  - русский язык

            NewsPageLocalizations.Add(new NewsPageLocalization { LanguageId = 1 });
            PortfolioPageLocalizations.Add(new PortfolioPageLocalization { LanguageId = 1 });
            PrivacyPageLocalizations.Add(new PrivacyPageLocalization { LanguageId = 1 });
            ServicesPageLocalizations.Add(new ServicesPageLocalization { LanguageId = 1 });

            AcceptOrderPopupLocalizations.Add(new AcceptOrderPopupLocalization { LanguageId = 1 });
            CallPopupLocalizations.Add(new CallPopupLocalization { LanguageId = 1 });
            ContactsPopupLocalizations.Add(new ContactsPopupLocalization { LanguageId = 1 });
            PortfolioPopupLocalizations.Add(new PortfolioPopupLocalization { LanguageId = 1 });

            CalculatorLocalizations.Add(new CalculatorLocalization { LanguageId = 1 });
            ErrorPagesLocalizations.Add(new ErrorPagesLocalization { LanguageId = 1 });
            MainPageLocalizations.Add(new MainPageLocalization { LanguageId = 1 });
            MapBlockLocalizations.Add(new MapBlockLocalization { LanguageId = 1 });
            SharedLocalizations.Add(new SharedLocalization { LanguageId = 1 });
        }
        #endregion

   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DatabaseSettings.ConnectionString,
                       new MySqlServerVersion(new Version(8, 0, 11)));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}