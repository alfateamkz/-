using Alfateam.DB;
using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam.Website.API.Models.ClientModels.General;
using Alfateam.Website.API.Models.Navigation;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Alfateam.Website.API.Controllers.General
{
    public class CommonController : AbsController
    {
        public CommonController(WebsiteDBContext db) : base(db)
        {
        }


        [HttpGet, Route("GetLanguages")]
        public async Task<IEnumerable<LanguageClientModel>> GetLanguages()
        {
            var items = DB.Languages.Include(o => o.Localizations)
                                    .Where(o => !o.IsDeleted && !o.IsHidden)
                                    .ToList();
            return LanguageClientModel.CreateItems(items, LanguageId);
        }

        [HttpGet, Route("GetCurrencies")]
        public async Task<IEnumerable<CurrencyClientModel>> GetCurrencies()
        {
            var items = DB.Currencies.Include(o => o.Localizations)
                                     .Where(o => !o.IsDeleted && !o.IsHidden)
                                     .ToList();
            return CurrencyClientModel.CreateItems(items, LanguageId);
        }

        [HttpGet, Route("GetCountries")]
        public async Task<IEnumerable<CountryClientModel>> GetCountries()
        {
            var items = DB.Countries.Include(o => o.Localizations)
                                    .Where(o => !o.IsDeleted && !o.IsHidden)
                                    .ToList();
            return CountryClientModel.CreateItems(items, LanguageId);
        }







        [HttpGet, Route("GetSitemap")]
        public async Task<Sitemap> GetSitemap()
        {
            //TODO: доработать сайтмап

            var sitemap = new Sitemap();
            sitemap.Items.Add(new SitemapItem("Glavnaya-stranitca", "/"));


            var countries = DB.Countries.Include(o => o.Languages)
                                        .Include(o => o.MainLanguage)
                                        .Include(o => o.OfficialMainLanguage)
                                        .Where(o => !o.IsDeleted);
            foreach (var country in countries)
            {
                foreach(var lang in country.Languages)
                {
                    var localTree = GetSitemapLocalTree(country, lang);
                    sitemap.Items.Add(localTree);
                }
            }
           

            return sitemap;
        }

        [HttpGet, Route("GetSitemapXML")]
        public async Task GetSitemapXML()
        {
            var sitemap = await GetSitemap();

            //var xmlFile = new XmlDocument();
            //foreach(var item in sitemap.Items)
            //{
            //    var node = xmlFile.CreateElement();
            //}


            //TODO: реализовать GetSitemapXML
        }

        private SitemapItem GetSitemapLocalTree(Country country,Language language)
        {
            var root = new SitemapItem($"{country.Code}-{language.Code}", "");

            //TODO: сделать получение локальных записей, а также переводы карты сайта


            root.Sublelements.Add(new SitemapItem("Komplaens", ""));
            root.Sublelements.Add(new SitemapItem("Autstaff", ""));
            root.Sublelements.Add(new SitemapItem("Partnery", ""));
            root.Sublelements.Add(new SitemapItem("Otzyvy", ""));
            root.Sublelements.Add(new SitemapItem("Politika-konfeditcialnosti", ""));
            root.Sublelements.Add(new SitemapItem("Statistika", ""));
            root.Sublelements.Add(new SitemapItem("Hronologiya", ""));
            root.Sublelements.Add(new SitemapItem("Poisk-dogovora", ""));


            root.Sublelements.Add(new SitemapItem("O-nas", ""));
            root.Sublelements.Add(new SitemapItem("Kontakty", ""));


            root.Sublelements.Add(new SitemapItem("Vhod", ""));
            root.Sublelements.Add(new SitemapItem("Registratciya", ""));
            root.Sublelements.Add(new SitemapItem("Vosstanovlenie-parolya", ""));


            var servicesBlock = new SitemapItem("Uslugi", "");
            root.Sublelements.Add(servicesBlock);

            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка web-приложений"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка CRM и ERP"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка мобильных приложений"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка прикладного и интерактивного ПО"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка мобильных приложений"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка приложений с AR и VR"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Автоматизации и интеграции"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Дизайн сайтов и мобильных приложений"), ""));
            servicesBlock.Sublelements.Add(new SitemapItem(SlugHelper.GetLatynSlug("Разработка интернет-магазинов"), ""));



            var teamBlock = new SitemapItem("Komanda", "");
            root.Sublelements.Add(teamBlock);

            //TODO: добавить команду


            root.Sublelements.Add(new SitemapItem("Rabota-menedjerom", ""));
            root.Sublelements.Add(new SitemapItem("Rabota-prodajnikom", ""));
            root.Sublelements.Add(new SitemapItem("Rabota-razrabotchikom", ""));

            var jobVacanciesBlock = new SitemapItem("Vakansii", "");
            root.Sublelements.Add(jobVacanciesBlock);
            foreach (var jobVacancy in DB.JobVacancies.Where(o => !o.IsDeleted))
            {
                var vacancyItem = new SitemapItem(jobVacancy.Slug, "");
                jobVacanciesBlock.Sublelements.Add(vacancyItem);
            }



            var shopBlock = new SitemapItem("Magazin", "");
            root.Sublelements.Add(shopBlock);
            foreach (var category in DB.ShopProductCategories.Where(o => !o.IsDeleted))
            {
                var categoryItem = new SitemapItem(category.Slug, "");
                shopBlock.Sublelements.Add(categoryItem);

                foreach (var product in DB.ShopProducts.Where(o => o.CategoryId == category.Id && !o.IsDeleted))
                {
                    var productItem = new SitemapItem(product.Slug, "");
                    categoryItem.Sublelements.Add(productItem);
                }
            }

            var newsBlock = new SitemapItem("Novosti", "");
            root.Sublelements.Add(shopBlock);
            foreach (var category in DB.PostCategories.Where(o => !o.IsDeleted))
            {
                var categoryItem = new SitemapItem(category.Slug, "");
                shopBlock.Sublelements.Add(categoryItem);

                foreach (var product in DB.Posts.Where(o => o.CategoryId == category.Id && !o.IsDeleted))
                {
                    var productItem = new SitemapItem(product.Slug, "");
                    categoryItem.Sublelements.Add(productItem);
                }
            }

            var eventsBlock = new SitemapItem("Sobytiya", "");
            root.Sublelements.Add(shopBlock);
            foreach (var category in DB.EventCategories.Where(o => !o.IsDeleted))
            {
                var categoryItem = new SitemapItem(category.Slug, "");
                shopBlock.Sublelements.Add(categoryItem);

                foreach (var product in DB.Events.Where(o => o.CategoryId == category.Id && !o.IsDeleted))
                {
                    var productItem = new SitemapItem(product.Slug, "");
                    categoryItem.Sublelements.Add(productItem);
                }
            }

            var portfiosBlock = new SitemapItem("Portfolio", "");
            root.Sublelements.Add(shopBlock);
            foreach (var category in DB.PortfolioCategories.Where(o => !o.IsDeleted))
            {
                var categoryItem = new SitemapItem(category.Slug, "");
                shopBlock.Sublelements.Add(categoryItem);

                foreach (var product in DB.Portfolios.Where(o => o.CategoryId == category.Id && !o.IsDeleted))
                {
                    var productItem = new SitemapItem(product.Slug, "");
                    categoryItem.Sublelements.Add(productItem);
                }
            }


            return root;
        }

        //private XmlNode LoadNodesRecursively(SitemapItem item)
        //{
        //    //var node = new XmlDocument().crea;
        //}
    }
}
