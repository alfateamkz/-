using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models.ClientModels;
using Alfateam.Website.API.Models.ClientModels.Portfolios;
using Alfateam2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Website.API.Controllers.Website
{
    public class PartnersController : AbsController
    {
        public PartnersController(WebsiteDBContext db, IWebHostEnvironment appEnv) : base(db, appEnv)
        {
        }


        [HttpGet, Route("GetPartners")]
        public async Task<IEnumerable<PartnerClientModel>> GetPartners(int offset, int count = 20)
        {
            var items = GetPartnersList().Skip(offset).Take(count).ToList();
            return PartnerClientModel.CreateItems(items, LanguageId);
        }

        [HttpGet, Route("GetPartner")]
        public async Task<PartnerClientModel> GetPartner(int id)
        {
            var partner = GetPartnersFullIncludedList().FirstOrDefault(o => o.Id == id);
            return PartnerClientModel.Create(partner, LanguageId);
        }




        #region Private get included methods
        public IQueryable<Partner> GetPartnersList()
        {
            return DB.Partners.IncludeAvailability()
                              .Include(o => o.Localizations)
                              .Include(o => o.Localizations).ThenInclude(o => o.Language)
                              .Include(o => o.MainLanguage)
                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        public IQueryable<Partner> GetPartnersFullIncludedList()
        {
            return DB.Partners.IncludeAvailability()
                              .Include(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.Language)
                              .Include(o => o.MainLanguage)
                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
