using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Models;
using Alfateam2._0.Models.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.General
{
    public class CommonController : AbsController
    {
        public CommonController(WebsiteDBContext db) : base(db)
        {
        }


        [HttpGet, Route("GetLanguages")]
        public async Task<IEnumerable<Language>> GetLanguages()
        {
            return DB.Languages.Where(o => !o.IsDeleted).ToList();
        }

        [HttpGet, Route("GetCurrencies")]
        public async Task<IEnumerable<Currency>> GetCurrencies()
        {
            return DB.Currencies.Where(o => !o.IsDeleted).ToList();
        }

        [HttpGet, Route("GetCountries")]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return DB.Countries.Where(o => !o.IsDeleted).ToList();
        }
    }
}
