using Alfateam.DB;
using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Helpers;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.General;
using Alfateam.Website.API.Models.DTO.Stats;
using Alfateam.Website.API.Models.Navigation;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Stats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace Alfateam.Website.API.Controllers.General
{
    public class CommonController : AbsController
    {
        public CommonController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetLanguages")]
        public async Task<IEnumerable<LanguageDTO>> GetLanguages()
        {
            var items = DB.Languages.Include(o => o.Localizations)
                                    .Where(o => !o.IsDeleted && !o.IsHidden)
                                    .ToList();
            return new LanguageDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<LanguageDTO>();
        }

        [HttpGet, Route("GetCurrencies")]
        public async Task<IEnumerable<CurrencyDTO>> GetCurrencies()
        {
            var items = DB.Currencies.Include(o => o.Localizations)
                                     .Where(o => !o.IsDeleted && !o.IsHidden)
                                     .ToList();
            return new CurrencyDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<CurrencyDTO>();
        }

        [HttpGet, Route("GetCountries")]
        public async Task<IEnumerable<CountryDTO>> GetCountries()
        {
            var items = DB.Countries.Include(o => o.Localizations)
                                    .Include(o => o.Languages)
                                    .Include(o => o.Currencies)
                                    .Where(o => !o.IsDeleted && !o.IsHidden)
                                    .ToList();
            return new CountryDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<CountryDTO>();
        }

        [HttpGet, Route("GetCountryFromIp")]
        public async Task<CountryDTO> GetCountryFromIp()
        {           
            var items = DB.Countries.Include(o => o.Localizations)
                                    .Include(o => o.Languages)
                                    .Include(o => o.Currencies)
                                    .Where(o => !o.IsDeleted && !o.IsHidden)
                                    .ToList();
          
            var userIp = HttpContext.Connection.RemoteIpAddress?.ToString();

            //Структура {"ip":"77.1.2.3","country":"DE"}
            var resp = await RequestHelper.ExecuteRequestReceiveModelAsync<dynamic>($"https://api.country.is/{userIp}", RestSharp.Method.Get);
            var country = items.FirstOrDefault(o => o.Code == resp.country);

            if(country == null)
            {
                country = items.FirstOrDefault(o => o.Code == "RU");
            }

            return (CountryDTO)new CountryDTO().CreateDTOWithLocalization(country, LanguageId);
        }





        [HttpPut, Route("AddSiteVisit")]
        public async Task AddSiteVisit(SiteVisitDTO model)
        {
            DbService.TryCreateEntity(DB.SiteVisits, model);
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
                                        .Where(o => !o.IsDeleted)
                                        .ToList();
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

            var structure = DB.TeamStructures
                .Include(o => o.Groups).ThenInclude(o => o.Members)
                .FirstOrDefault();

            if(structure != null)
            {
                foreach (var member in structure.Groups.SelectMany(o => o.Members))
                {
                    teamBlock.Sublelements.Add(new SitemapItem($"{member.Name} {member.Surname} - {member.Position}", ""));
                }
            }

           

    


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
