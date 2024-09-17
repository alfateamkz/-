using Alfateam.DB;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Extensions;
using Alfateam.Website.API.Models;
using Alfateam.Website.API.Models.DTO;
using Alfateam.Website.API.Models.DTO.Portfolios;
using Alfateam2._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Alfateam.Website.API.Controllers.Website
{
    public class PartnersController : AbsController
    {
        public PartnersController(ControllerParams @params) : base(@params)
        {
        }


        [HttpGet, Route("GetPartners")]
        public async Task<IEnumerable<PartnerDTO>> GetPartners(int offset, int count = 20)
        {
            var items = GetPartnersList().Skip(offset).Take(count).ToList();
            return new PartnerDTO().CreateDTOsWithLocalization(items, LanguageId).Cast<PartnerDTO>();
        }

        [HttpGet, Route("GetPartner")]
        public async Task<PartnerDTO> GetPartner(int id)
        {
            var partner = GetPartnersFullIncludedList().FirstOrDefault(o => o.Id == id);
            return (PartnerDTO) new PartnerDTO().CreateDTOWithLocalization(partner, LanguageId);
        }




        #region Private get included methods
        private IQueryable<Partner> GetPartnersList()
        {
            return DB.Partners.IncludeAvailability()
                              .Include(o => o.Localizations)
                              .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                              .Include(o => o.MainLanguage)
                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }
        private IQueryable<Partner> GetPartnersFullIncludedList()
        {
            return DB.Partners.IncludeAvailability()
                              .Include(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.Content).ThenInclude(o => o.Items)
                              .Include(o => o.Localizations).ThenInclude(o => o.LanguageEntity)
                              .Include(o => o.MainLanguage)
                              .Where(o => !o.IsDeleted && o.Availability.IsAvailable(CountryId));
        }

        #endregion
    }
}
