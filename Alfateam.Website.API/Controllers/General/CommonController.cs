using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Core.Helpers;
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
using Alfateam.Website.API.Helpers;
using Alfateam2._0.Models.Localization.Texts.Grouping;
using Alfateam.Website.API.Jobs;

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

            Country country = null;
            var userIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            var resp = await RequestHelper.ExecuteRequestReceiveModelAsync<ApiCountryIsModel>($"https://api.country.is/{userIp}", RestSharp.Method.Get);

            if(resp != null)
            {
                country = items.FirstOrDefault(o => o.Code == resp.Country);
            }
      
            if(country == null)
            {
                country = items.FirstOrDefault(o => o.Code == "RU");
            }

            return (CountryDTO)new CountryDTO().CreateDTOWithLocalization(country, LanguageId);
        }





        [HttpPut, Route("AddSiteVisit")]
        public async Task AddSiteVisit(SiteVisitDTO model)
        {
            model.VisitedById = this.Session?.UserId;
            DbService.TryCreateEntity(DB.SiteVisits, model);
        }



        [HttpGet, Route("GetSitemap")]
        public async Task<Sitemap> GetSitemap()
        {
            //TODO: доработать сайтмап
            return SitemapHelper.GetSitemap(DB);
        }

        [HttpGet, Route("GetWebsiteTextsLocalization")]
        public async Task<WebsiteLocalizationTexts> GetWebsiteTextsLocalization()
        {
            return StaticFilesJob.GetWebsiteLocalizationWithIncludes(DB, (int)this.LanguageId);
        }




        [HttpPost, Route("SendForm")]
        public async Task SendForm(SentFromWebsiteFormDTO model)
        {
            DbService.TryCreateEntity(DB.SentFromWebsiteForms, model, (entity) =>
            {
                entity.SentByUserId = this.Session?.UserId;
                entity.IP = HttpContext.Connection.RemoteIpAddress?.ToString();
            });
        }
    }
}
