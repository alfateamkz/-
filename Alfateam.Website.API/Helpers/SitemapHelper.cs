using Alfateam.Core.Helpers;
using Alfateam.CRM2_0.Models.General.Services;
using Alfateam.DB;
using Alfateam.Website.API.Models.Navigation;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.General;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Helpers
{
    public static class SitemapHelper
    {
        public static Sitemap GetSitemap(WebsiteDBContext db)
        {
            //TODO: миграция

            var sitemap = new Sitemap();
            sitemap.Items.Add(new SitemapItem("", "alfateam.co website"));


            var countries = db.Countries.Include(o => o.Languages)
                                        .Include(o => o.MainLanguage)
                                        .Include(o => o.OfficialMainLanguage)
                                        .Where(o => !o.IsDeleted)
                                        .ToList();
            foreach (var country in countries)
            {
                foreach (var lang in country.Languages)
                {
                    var localTree = GetSitemapLocalTree(db, country, lang);
                    sitemap.Items.Add(localTree);
                }
            }


            return sitemap;
        }

        public static SitemapItem GetSitemapLocalTree(WebsiteDBContext db, Country country, Language language)
        {

            var sitemapPageTitles = db.SitemapPageTitlesTexts.FirstOrDefault(o => o.LanguageEntityId == language.Id);

            if(sitemapPageTitles == null)
            {
                sitemapPageTitles = db.SitemapPageTitlesTexts.Include(o => o.LanguageEntity)
                                                             .FirstOrDefault(o => o.LanguageEntity.Code == "RU");
            }


            var root = new SitemapItem($"{country.Code}-{language.Code}", sitemapPageTitles.MainPage);

            //TODO: сделать получение локальных записей (availability)


            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Compliance), sitemapPageTitles.Compliance));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Outstaff), sitemapPageTitles.Outstaff));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Patners), sitemapPageTitles.Patners));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Reviews), sitemapPageTitles.Reviews));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.PrivacyPolicy), sitemapPageTitles.PrivacyPolicy));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Stats), sitemapPageTitles.Stats));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Chronology), sitemapPageTitles.Chronology));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.AgreementSearch), sitemapPageTitles.AgreementSearch));


            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.AboutUs), sitemapPageTitles.AboutUs));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Contacts), sitemapPageTitles.Contacts));


            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.SignIn), sitemapPageTitles.SignIn));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.SignUp), sitemapPageTitles.SignUp));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.RestorePassword), sitemapPageTitles.RestorePassword));


            var servicesBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Services), sitemapPageTitles.Services);
            root.AddElement(servicesBlock);

            foreach (var service in db.ServicePages.Include(o => o.Localizations).Where(o => !o.IsDeleted).ToList())
            {
                var localizedSlug = GetLocalizedSlug(service.Slug, language.Id, service.Localizations);
                var localizedTitle = GetLocalizedProperty(service.MainBlockHeader, "MainBlockHeader", language.Id, service.Localizations);

                var serviceItem = new SitemapItem(localizedSlug, localizedTitle);
                servicesBlock.AddElement(serviceItem);
            }


            var teamBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Team), sitemapPageTitles.Team);
            root.AddElement(teamBlock);

            var structure = db.TeamStructures
                .Include(o => o.Groups).ThenInclude(o => o.Members).ThenInclude(o => o.Localizations)
                .ToList()
                .FirstOrDefault();

            if (structure != null)
            {
                foreach (var member in structure.Groups.SelectMany(o => o.Members))
                {
                    var localizedSlug = GetLocalizedSlug(member.Slug, language.Id, member.Localizations);
                    var localizedTitle = GetLocalizedProperty(member.ShownTitle, "ShownTitle", language.Id, member.Localizations);

                    teamBlock.AddElement(new SitemapItem(localizedSlug, localizedTitle));
                }
            }






            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.ProjectManagerJobLanding), sitemapPageTitles.ProjectManagerJobLanding));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.SalesManagerJobLanding), sitemapPageTitles.SalesManagerJobLanding));
            root.AddElement(new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.EmployeeJobLanding), sitemapPageTitles.EmployeeJobLanding));

            var jobVacanciesBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.JobVacancies), sitemapPageTitles.JobVacancies);
            root.AddElement(jobVacanciesBlock);
            foreach (var jobVacancy in db.JobVacancies.Include(o => o.Localizations).Where(o => !o.IsDeleted).ToList())
            {
                var localizedSlug = GetLocalizedSlug(jobVacancy.Slug, language.Id, jobVacancy.Localizations);
                var localizedTitle = GetLocalizedProperty(jobVacancy.Title, "Title", language.Id, jobVacancy.Localizations);

                var vacancyItem = new SitemapItem(localizedSlug, localizedTitle);
                jobVacanciesBlock.AddElement(vacancyItem);
            }



            var shopBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Shop), sitemapPageTitles.Shop);
            root.AddElement(shopBlock);
            foreach (var category in db.ShopProductCategories.Include(o => o.Localizations).Where(o => !o.IsDeleted).ToList())
            {
                var categoryLocalizedSlug = GetLocalizedSlug(category.Slug, language.Id, category.Localizations);
                var categoryLocalizedTitle = GetLocalizedProperty(category.Title, "Title", language.Id, category.Localizations);

                var categoryItem = new SitemapItem(categoryLocalizedSlug, categoryLocalizedTitle);
                shopBlock.AddElement(categoryItem);

                foreach (var product in db.ShopProducts.Include(o => o.Localizations).Where(o => o.CategoryId == category.Id && !o.IsDeleted).ToList())
                {
                    var productLocalizedSlug = GetLocalizedSlug(product.Slug, language.Id, product.Localizations);
                    var productLocalizedTitle = GetLocalizedProperty(product.Title, "Title", language.Id, product.Localizations);

                    var productItem = new SitemapItem(productLocalizedSlug, productLocalizedTitle);
                    categoryItem.AddElement(productItem);
                }
            }

            var newsBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Posts), sitemapPageTitles.Posts);
            root.AddElement(shopBlock);
            foreach (var category in db.PostCategories.Include(o => o.Localizations).Where(o => !o.IsDeleted).ToList())
            {
                var categoryLocalizedSlug = GetLocalizedSlug(category.Slug, language.Id, category.Localizations);
                var categoryLocalizedTitle = GetLocalizedProperty(category.Title, "Title", language.Id, category.Localizations);

                var categoryItem = new SitemapItem(categoryLocalizedSlug, categoryLocalizedTitle);
                shopBlock.AddElement(categoryItem);

                foreach (var post in db.Posts.Include(o => o.Localizations).Where(o => o.CategoryId == category.Id && !o.IsDeleted).ToList())
                {
                    var postLocalizedSlug = GetLocalizedSlug(post.Slug, language.Id, post.Localizations);
                    var postLocalizedTitle = GetLocalizedProperty(post.Title, "Title", language.Id, post.Localizations);

                    var postItem = new SitemapItem(postLocalizedSlug, postLocalizedTitle);
                    categoryItem.AddElement(postItem);
                }
            }

            var eventsBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Events), sitemapPageTitles.Events);
            root.AddElement(shopBlock);
            foreach (var category in db.EventCategories.Include(o => o.Localizations).Where(o => !o.IsDeleted).ToList())
            {
                var categoryLocalizedSlug = GetLocalizedSlug(category.Slug, language.Id, category.Localizations);
                var categoryLocalizedTitle = GetLocalizedProperty(category.Title, "Title", language.Id, category.Localizations);

                var categoryItem = new SitemapItem(categoryLocalizedSlug, categoryLocalizedTitle);
                shopBlock.AddElement(categoryItem);

                foreach (var eventModel in db.Events.Include(o => o.Localizations).Where(o => o.CategoryId == category.Id && !o.IsDeleted).ToList())
                {
                    var eventLocalizedSlug = GetLocalizedSlug(eventModel.Slug, language.Id, eventModel.Localizations);
                    var eventLocalizedTitle = GetLocalizedProperty(eventModel.Title, "Title", language.Id, eventModel.Localizations);

                    var eventItem = new SitemapItem(eventLocalizedSlug, eventLocalizedTitle);
                    categoryItem.AddElement(eventItem);
                }
            }

            var portfiosBlock = new SitemapItem(SlugHelper.GetLatynSlug(sitemapPageTitles.Portfolio), sitemapPageTitles.Portfolio);
            root.AddElement(shopBlock);
            foreach (var category in db.PortfolioCategories.Include(o => o.Localizations).Where(o => !o.IsDeleted).ToList())
            {
                var categoryLocalizedSlug = GetLocalizedSlug(category.Slug, language.Id, category.Localizations);
                var categoryLocalizedTitle = GetLocalizedProperty(category.Title, "Title", language.Id, category.Localizations);

                var categoryItem = new SitemapItem(categoryLocalizedSlug, categoryLocalizedTitle);
                shopBlock.AddElement(categoryItem);

                foreach (var portfolio in db.Portfolios.Include(o => o.Localizations).Where(o => o.CategoryId == category.Id && !o.IsDeleted).ToList())
                {
                    var portfolioLocalizedSlug = GetLocalizedSlug(portfolio.Slug, language.Id, portfolio.Localizations);
                    var portfolioLocalizedTitle = GetLocalizedProperty(portfolio.Title, "Title", language.Id, portfolio.Localizations);

                    var portfolioItem = new SitemapItem(portfolioLocalizedSlug, portfolioLocalizedTitle);
                    categoryItem.AddElement(portfolioItem);
                }
            }


            return root;
        }

        private static string GetLocalizedSlug(string mainLangSlug, int langId, IEnumerable<LocalizableModel> localizations)
        {
            return GetLocalizedProperty(mainLangSlug,"Slug", langId, localizations);
        }

        private static string GetLocalizedProperty(string mainLangPropValue, string propName, int langId, IEnumerable<LocalizableModel> localizations)
        {
            var found = localizations.FirstOrDefault(o => o.LanguageEntityId == langId);
            if (found != null)
            {
                return found.GetType().GetProperties().FirstOrDefault(o => o.Name == propName).GetValue(found) as string;
            }
            return mainLangPropValue;
        }
    }
}
